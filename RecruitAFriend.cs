using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Styx;
using Styx.Common;
using Styx.Plugins;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using Styx.CommonBot;
using Styx.Helpers;
using Styx.CommonBot.Profiles;
using Styx.CommonBot.Inventory;
using System.Threading.Tasks;

namespace RecruitAFriend
{
 
    public enum EnumLootThreshold
    {
        Uncommon =1,
        Rare = 2,
        Epic = 3
    }

    public enum EnumLootMethod
    {
        Group,
        FreeForAll,
        Master,
        NeedBeforeGreed,
        RoundRobin
    }

    public enum EnumInteractDistance
    {
        Inspect = 1,
        Trade = 2,
        Duel = 3,
        Follow = 4
    }

    public struct StructureLootMethod
    {
        EnumLootMethod lootmethod;
        dynamic masterlooterPartyID;
        dynamic masterlooterRaidID;
    }

    // Battle.Net Structures
    public struct StructureBattleNetInfo {
        int presenceID;
        int toonID;
        string currentBroadcast;
        bool bnetAFK;
        bool bnetDND;
    }

    public struct StructureBattleNetFriendInfo
    {
        int presenceID;
        string givenName;
        string surname;
        string toonName;
        int toonID;
        string client;
        bool isOnline;
    }

    public struct StructureBattleNetFriendInfoFromID
    {
        int presenceID;
        string givenName;
        string surname;
        string toonName;
        int toonID;
        string client;
        bool isOnline;
        DateTime lastOnline;
        bool isAFK;
        bool isDND;
        string messageText;
        string noteText;
    }

    public struct StructureBattleNetToonInfo
    {
        dynamic unused1;
        dynamic unused2; 
        string gameName;
        string realmName;
        string faction;
        dynamic unused3;
        string race;
        string charclass;
        dynamic unused4;
        string zoneName;
        int level;
    }

    public struct StructureQuestLogTitle
    {
        string questTitle;
        int level;
        string questTag;
        string suggestedGroup;
        dynamic isHeader;
        dynamic sCollapsed;
        bool isComplete;
        bool isDaily;
        int questID;
    }

    // ******************************
    // **       PLUGIN CORE        **
    // ******************************
    public class RecruitAFriend : HBPlugin
    {
        public WoWUnit lastQGtarget = null;
        public long inRange = 0;
        public Random rng = new Random();
        public int resetTurnIn = 0;
        public LocalPlayer Me = StyxWoW.Me;


        // Name of the plugin
        public override string Name
        {
            get { return "RecruitAFriend"; }
        }

        // Give credits to the developer(s)
        public override string Author
        {
            get { return "RecruitAFriend Team + Paul1337noob"; }
        }

        // What is the version
        public override Version Version
        {
            get { return new Version(0, 0, 0, 1); }
        }

        // Enable plugin "settings" button
        public override bool WantButton
        {
            get { return true; }
        }

        // Set caption of "settings" button
        public override string ButtonText
        {
            get { return "Settings"; }
        }

        // What happens when a user clicks the "settings" button
        public override void OnButtonPress()
        {
            var settings = new RecruitAFriendSettings();
            settings.ShowDialog();

            // MessageBox.Show("Configuration options will be here later","Settings ...",MessageBoxButtons.YesNo);
            
        }



        // Code to run when the plugin is enabled in HonorBuddy
        public override void OnEnable()
        {

            try { 
                Logging.Write("[RAF Edit] Enabled");
                Functions.AcceptInvite();



                // Battle.Net
                Lua.Events.AttachEvent("BN_CONNECTED", Events.BN_CONNECTED);
                Lua.Events.AttachEvent("BN_FRIEND_ACCOUNT_ONLINE", Events.BN_FRIEND_ACCOUNT_ONLINE);

                // Party
                Lua.Events.AttachEvent("PARTY_INVITE_REQUEST", Events.PARTY_INVITE_REQUEST);
                Lua.Events.AttachEvent("PARTY_MEMBERS_CHANGED", Events.PARTY_MEMBERS_CHANGED);
                

                // Recruit-A-Friend
                Lua.Events.AttachEvent("CONFIRM_SUMMON", Events.CONFIRM_SUMMON);
                Lua.Events.AttachEvent("LEVEL_GRANT_PROPOSED", Events.LEVEL_GRANT_PROPOSED);
                Lua.Events.AttachEvent("PLAYER_LEVEL_UP", Events.PLAYER_LEVEL_UP);

                // Questing
                Lua.Events.AttachEvent("QUEST_DETAIL", Events.QUEST_DETAIL);

                Settings.Load();

                base.OnEnable();
                
            }
            catch (Exception e)
            {
                // Exception handling
            }
            finally
            {
                // Command completed properly
            }
        }

        // Code to run when the plugin is disabled in HonorBuddy
        public override void OnDisable()
        {
            try
            {
                Logging.Write("[RAF Edit] Disabled");
                // Battle.Net
                Lua.Events.DetachEvent("BN_CONNECTED", Events.BN_CONNECTED);
                Lua.Events.DetachEvent("BN_FRIEND_ACCOUNT_ONLINE", Events.BN_FRIEND_ACCOUNT_ONLINE);

                // Party
                Lua.Events.DetachEvent("PARTY_INVITE_REQUEST", Events.PARTY_INVITE_REQUEST);
                Lua.Events.DetachEvent("PARTY_MEMBERS_CHANGED", Events.PARTY_MEMBERS_CHANGED);

                // Recruit-A-Friend
                Lua.Events.DetachEvent("CONFIRM_SUMMON", Events.CONFIRM_SUMMON);
                Lua.Events.DetachEvent("LEVEL_GRANT_PROPOSED", Events.LEVEL_GRANT_PROPOSED);
                Lua.Events.DetachEvent("PLAYER_LEVEL_UP", Events.PLAYER_LEVEL_UP);

                // Questing
                Lua.Events.DetachEvent("QUEST_DETAIL", Events.QUEST_DETAIL);


                

                base.OnDisable();
            }
            catch (Exception e)
            {
                // Exception handling
            }
            finally
            {
                // Command completed properly
            }
        }

        // Code to run when HonorBuddy pings the plugin (on heartbeat return pulse)
        public override void Pulse()
        {
            TargetQGT();
        }

        private async void TargetQGT()
        {
            
            uint partySize = 2;
            if (partySize != Me.GroupInfo.PartySize)
            {
                partySize = Me.GroupInfo.PartySize;
                Logging.Write(" - We are " + partySize.ToString() + " party members.");
            }

            if (Me.CurrentTarget != null)
            {
                if (Me.CurrentTarget.QuestGiverStatus == QuestGiverStatus.TurnIn)
                {
                    if (Me.CurrentTarget.WithinInteractRange)
                    {
                        WoWMovement.MoveStop();
                        if (partyMemberInRange())
                        {
                            if (lastQGtarget != Me.CurrentTarget || Me.CurrentTarget == null)
                            {
                                Logging.Write( " - All members are within range.");
                                Logging.Write( " - Waiting 8 seconds before turning in the quest.");
                                inRange = 0;
                             
                                await Task.Delay(8000);
                                //Will turn in quest here if all arguments are passed.
                            }

                            if (Me.CurrentTarget != null)
                                lastQGtarget = Me.CurrentTarget;
                            return;
                        }
                        else
                        {
                            if (Styx.CommonBot.Frames.QuestFrame.Instance.IsVisible || Styx.CommonBot.Frames.GossipFrame.Instance.IsVisible)
                            {
                                Styx.CommonBot.Frames.QuestFrame.Instance.Close();
                                Styx.CommonBot.Frames.GossipFrame.Instance.Close();
                            }
                            return;
                        }
                    }
                }
            }

            if (lastQGtarget != null)
            {
                if (lastQGtarget.WithinInteractRange)
                {
                    if (lastQGtarget.QuestGiverStatus == QuestGiverStatus.TurnIn)
                    {
                        lastQGtarget.Target();
                        TargetQGT();
                    }
                    if (lastQGtarget.QuestGiverStatus == QuestGiverStatus.Available || lastQGtarget.QuestGiverStatus == QuestGiverStatus.Available || lastQGtarget.QuestGiverStatus == QuestGiverStatus.AvailableRepeatable || lastQGtarget.QuestGiverStatus == QuestGiverStatus.LowLevelAvailable || lastQGtarget.QuestGiverStatus == QuestGiverStatus.None)
                    {

                        int waitTime = rng.Next(5, 8);
                        Logging.Write(" - I am in a " + waitTime.ToString() + " seconds wait period.");
                        WoWMovement.MoveStop();
                                             
                   
                        if (TreeRoot.IsRunning) TreeRoot.Pause();
                        await Task.Delay(waitTime * 10000);
                        if (!TreeRoot.IsRunning) TreeRoot.Resume();


                        if (Me.PartyMembers.Count(player => player != null && player.IsValid && player.CurrentTarget == lastQGtarget && lastQGtarget != null) > 0)
                        {
                            Logging.Write(" - My other party member(s) is still turning in the quest(s), waiting again.");
                            resetTurnIn++;
                            if (resetTurnIn == 2)
                            {
                                Logging.Write(" - I've waited 2 times extra now, assuming we only were stuck in a loop.");
                                resetTurnIn = 1;
                                lastQGtarget = null;
                                return;
                            }
                            TargetQGT();
                        }
                    }
                }
                lastQGtarget = null;
            }

            return;
        }

        private bool partyMemberInRange()
        {
            uint partySize = 2;
            long inRange = 0;
            int membersInRange = Me.PartyMembers.Count(player => player != null && Me.Location.Distance(player.Location) <= 10);
            if (membersInRange == partySize && membersInRange != 0)
            {
                return true;
            }
            else
            {
                if (inRange != (partySize - membersInRange))
                {
                    inRange = (partySize - membersInRange);
                    Logging.Write(" - " + (partySize - membersInRange).ToString() + " player(s) are out of range.");
                }
                return false;
            }
        }
    }





    // ******************************
    // **       LUA EVENTS         **
    // ******************************
    public class Events
    {

        public static String Leader
        {
            get { return "Ilylilu"; }
        }
        public static String Toon
        {
            get { return "Ilyluli"; }
        }


        public static LocalPlayer Me = StyxWoW.Me;

        // Battle.net Events
        public static void BN_CONNECTED(object sender, LuaEventArgs args)
        {
            Logging.Write("[RAF Edit] a");
        }

        public static void BN_FRIEND_ACCOUNT_ONLINE(object sender, LuaEventArgs args)
        {
            Logging.Write("[RAF Edit] b");
            Lua.DoString("RunMacroText(\"/invite "+Toon +"\")");
            Logging.Write("[RAF Edit] invite " + Toon + " " + Functions.InviteUnit(Toon));

        }

        // Party Events
        public static void PARTY_MEMBERS_CHANGED(object sender, LuaEventArgs args)
        {
            Logging.Write("[RAF Edit] c");
            //Lua.DoString("RunMacroText(\"/script SummonFriend(" + Toon + ")\")");
            Functions.SummonFriend(Toon);
        }

        public static void PARTY_INVITE_REQUEST(object sender, LuaEventArgs args)
        {
           
            String partyInviteSender = args.Args[0].ToString();
            Logging.Write("[RAF Edit] Invite from: " + partyInviteSender);
            if (partyInviteSender == Leader)
            {
                Lua.DoString("RunMacroText(\"/script AcceptGroup();\")");
            }
            else { }
        }

        // Recruit-A-Friend Events
        public static void CONFIRM_SUMMON(object sender, LuaEventArgs args)
        {
            Functions.ConfirmSummon();
            Functions.CancelSummon();
        }

        public static void LEVEL_GRANT_PROPOSED(object sender, LuaEventArgs args)
        {
            Functions.AcceptLevelGrant();
            Functions.DeclineLevelGrant();
        }
        
        public static void PLAYER_LEVEL_UP(object sender, LuaEventArgs args)
        {

        }

        // Questing
        public static void QUEST_DETAIL(object sender, LuaEventArgs args)
        {
           
            //int q = (int) Lua.DoString("GetNumQuestLogEntries()");
            //for(int i = 0; i < q; i++)
           // {
              //  Lua.DoString("SelectQuestLogEntry("+i+")");
             //   Lua.DoString("QuestLogPushQuest()");
           // }
            Logging.Write("[RAF Edit] ab");
            
            Functions.AcceptQuest();
            Functions.DeclineQuest();
        }

       



    }

    // ******************************
    // **       LUA FUNCTIONS      **
    // ******************************
    public class Functions
    {

        // Battle.Net Functions
        public static StructureBattleNetInfo BNGetInfo()
        {
            List<string> values;
            values = Lua.GetReturnValues("BNGetInfo()");
            return new StructureBattleNetInfo();
        }

        public static StructureBattleNetToonInfo BNGetToonInfo(string presence) // This may require a structure to be passed instead of a string
        {
            List<string> values;
            values = Lua.GetReturnValues("BNGetToonInfo(" + presence + ")");
            return new StructureBattleNetToonInfo();
        }

        public static int BNGetNumFriends()
        {
            List<string> values;
            values = Lua.GetReturnValues("BNGetNumFriends()");
            return Convert.ToInt32( values[0] );
        }

        public static StructureBattleNetFriendInfo BNGetFriendInfo(int index)
        {
            List<string> values;
            values = Lua.GetReturnValues("BNGetFriendInfo(" + index + ")");
            return new StructureBattleNetFriendInfo();
        }

        public static StructureBattleNetFriendInfoFromID BNGetFriendInfoByID(int presence)
        {
            List<string> values;
            values = Lua.GetReturnValues("BNGetFriendInfoByID(" + presence + ")");
            return new StructureBattleNetFriendInfoFromID();
        }

        public static bool CanCooperateWithToon(StructureBattleNetInfo info)
        {
            List<string> values;
            values = Lua.GetReturnValues("CanCooperateWithToon(" + info + ")"); 
            return Convert.ToBoolean( values[0] );
        }


        // Party Functions
        public static bool IsPartyLeader()
        {
            List<string> values;
            values = Lua.GetReturnValues("IsPartyLeader()");
            return Convert.ToBoolean( values[0] );
        }

        public static string InviteUnit(string name)
        {
            Lua.DoString("InviteUnit(" + name + ")");
            return "done";
        }

        public static void AcceptInvite()
        {
            Lua.DoString("AcceptGroup()");
            return;
        }

        public static void DeclineGroup()
        {
            Lua.DoString("DeclineGroup()");
            return;
        }

        public static StructureLootMethod GetLootMethod()
        {
            List<string> values;
            values = Lua.GetReturnValues("GetLootMethod()"); 
            return new StructureLootMethod();
        }

        public static void SetLootMethod(EnumLootMethod method)
        {
            string strmethod = "roundrobin";
            switch (method)
            {
                case EnumLootMethod.FreeForAll:
                    strmethod = "freeforall";
                    break;
                case EnumLootMethod.Group:
                    strmethod = "group";
                    break;
                case EnumLootMethod.Master:
                    strmethod = "master";
                    break;
                case EnumLootMethod.NeedBeforeGreed:
                    strmethod = "needbeforegreed";
                    break;
                case EnumLootMethod.RoundRobin:
                    strmethod = "roundrobin";
                    break;
            }
            Lua.DoString("SetLootMethod(" + strmethod + ")");
        }

        public static void SetLootThreshold(EnumLootThreshold threshold)
        {
            Lua.DoString("SetLootThreshold(" + threshold + ")");
        }

        // Recruit-A-Friend Functions
        public static bool IsReferAFriendLinked(string name)
        {
            List<string> values;
            values = Lua.GetReturnValues("IsReferAFriendLinked(" + name + ")");
            return Convert.ToBoolean( values[0] );
        }

        public static int GetSummonFriendCooldown()
        {
            List<string> values;
            values = Lua.GetReturnValues("GetSummonFriendCooldown()");
            return Convert.ToInt32( values[0] ); // 1 Hour
        }

        public static void SummonFriend(string name)
        {
            Lua.DoString("SummonFriend(" + name + ")");
        }

        public static void ConfirmSummon()
        {
            Lua.DoString("ConfirmSummon()");
        }

        public static void CancelSummon()
        {
            Lua.DoString("CancelSummon()");
        }

        public static void GrantLevel(string name)
        {
            Lua.DoString("GrantLevel(" + name + ",1)");        
        }

        public static void AcceptLevelGrant()
        {
            Lua.DoString("AcceptLevelGrant();");
        }

        public static void DeclineLevelGrant()
        {
            Lua.DoString("DeclineLevelGrant()");
        }

        public static bool CheckInteractDistance(string name, EnumInteractDistance distance)
        {
            List<string> values;
            values = Lua.GetReturnValues("CheckInteractDistance(" + name + "," + distance + ")");
            return Convert.ToBoolean( values[0] );
        }

        // Mounts
        // More commands here :  http://wowprogramming.com/docs/api_categories#vehicle
        public static void EjectPassengerFromSeat(int seat)
        {
            Lua.DoString("EjectPassengerFromSeat(" + seat + ")");
        }

        // Trading
        // More commands here : http://wowprogramming.com/docs/api_categories#trade

        // Questing
        public static StructureQuestLogTitle GetQuestLogTitle(int id)
        {
            List<string> values;
            values = Lua.GetReturnValues("GetQuestLogTitle(" + id + ")");
            return new StructureQuestLogTitle();
        }

        public static int GetNumQuestLogEntries()
        {
            List<string> values;
            values = Lua.GetReturnValues("GetNumQuestLogEntries()");
            return Convert.ToInt32(values[1]);
        }

        public static void AcceptQuest()
        {
            Logging.Write("[RAF Edit] aa");
            Lua.DoString("QuestLogPushQuest();");
            Lua.DoString("AcceptQuest()");
            return;
        }

        public static void DeclineQuest()
        {
            Lua.DoString("DeclineQuest()");
            return;
        }
    }

    // ******************************
    // **       Settings           **
    // ******************************
    public class Settings
    {


        public static void Save(String L, String F)
        {

        }

        public static void Load()
        {
          
        }
    }
}
