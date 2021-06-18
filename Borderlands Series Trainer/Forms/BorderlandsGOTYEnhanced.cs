using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System;
using Memory;

///---=>xCENTx<=--- \\\
///---=>#0001<=--- \\\

/// ||-FUNCTIONS-|| \\\
/// // 
/// No Recoil
/// Inf Money
/// Inf Health
/// Inf Shields
/// Inf Ammo
/// Inf Golden Keys
/// Inf Skill Points
/// Max XP
/// XP Multiplier
/// Much, Much, More ... Check Out OFFSETS
/// //

/// ||-CONTROLS-|| \\\
/// //
/// NUMPAD 0 = REFILL HEALTH , SHIELDS & AMMO ||
/// NUMPAD 1 = NO RECOIL TOGGLE ||
/// NUMPAD 2 = EMPTY ||
/// NUMPAD 3 = EMPTY ||
/// NUMPAD 4 = EMPTY ||
/// NUMPAD 5 = EMPTY ||
/// NUMPAD 6 = EMPTY ||
/// NUMPAD 7 = EMPTY ||
/// NUMPAD 8 = EMPTY ||
/// NUMPAD 9 = EMPTY ||
/// //

namespace MultipleGameTrainerSource.Forms
{
    public partial class BorderlandsGOTYEnhanced : Form
    {
        #region //Imports

        //Memory.dll
        Mem m = new Mem();
        bool BLRunning = false;
        private const string BORDERLANDSPROCESS = "BorderlandsGOTY.exe";

        //Hotkey Usage
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        //Numpad Stuff
        bool HotkeysToggled = false;
        bool HealthToggled = false;
        bool AmmoToggled = false;
        bool MoneyToggled = false;
        bool KeysToggled = false;

        //XP Multiplier
        public class XP
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }

        #endregion

        #region //Offsets

        public static class Offsets
        {
            //Player Info
            public const string Money = "0x025C1D90,0x68,0x550,0x1F8,0x350";                                //Int
            public const string GoldenKeyTotal = "0x025C1D90,0x68,0x550,0x1B8,0x1070,0x64,0x300";           //Int
            public const string SkillPoints = "0x025C1D90,0x68,0x550,0x1F8,0x348";                          //Int
            public const string GoldenKeyUsed = "0x025C1D90,0x68,0x550,0x1B8,0x1070,0x64,0x31C";            //Int
            public const string SkillCooldown = "0x025C1D90,0x68,0x550,0x1F8,0x36C,0x270,0x98";             //Float
            public const string Level = "0x025C1D90,0x68,0x550,0x1F8,0x32C";                                //Int
            public const string Experience = "0x025C1D90,0x68,0x550,0x1F8,0x358,0x268,0x98";                //Float
            public const string Health = "0x025C1D90,0x68,0x550,0x1F8,0x364,0x98";                          //Float
            public const string MaxHealth = "0x025C1D90,0x68,0x550,0x1F8,0x364,0x80";                       //Float
            public const string Shield = "0x025C1D90,0x68,0x550,0x390,0x290,0x98";                          //Float
            public const string MaxShield = "0x025C1D90,0x68,0x550,0x390,0x290,0x80";                       //Float
            public const string SkillCooldownTimerMax = "0x025C1D90,0x68,0x550,0x1F8,0x36C,0x270,0x80";     //Float
            public const string XPMultiplier = "0x025C1D90,0x68,0x550,0x1F8,0x358,0x268,0x194";             //Float
            public const string MaxXP = "0x025C1D90,0x68,0x550,0x1F8,0x358,0x268,0x80";                     //Float

            //Player Position (Working so far)
            public const string CameraPitch = "0x02555AA8,0xC4,0x630,0x10,0x9C";            //Int
            public const string CameraYaw = "0x02555AA8,0xC4,0x630,0x10,0xA0";              //Int
            public const string PlayerX = "0x025C1DA0,0x18,0x40,0x90";                      //Float
            public const string PlayerY = "0x025C1DA0,0x18,0x40,0x94";                      //Float
            public const string PlayerZ = "0x025C1DA0,0x18,0x40,0x98";                      //Float
            public const string PlayerDeltaX = "0x02555C38,0x124,0x0,0x17C";                //Float
            public const string PlayerDeltaY = "0x02555C38,0x124,0x0,0x180";                //Float
            public const string PlayerDeltaZ = "0x02555C38,0x124,0x0,0x184";                //Float
            public const string PlayerMovementSpeed = "0x02555C38,0x124,0x0,0x37C";         //Float
            public const string BaseMovementSpeed = "0x02555C38,0x124,0x0,0x380"; 	        //Float
            public const string isSprinting = "0x02555C38,0x124,0x0,0x38C"; 	            //Int
            public const string JumpHeight = "0x02555C38,0x124,0x0,0x3B8";                  //Float
            public const string BaseJumpHeight = "0x02555C38,0x124,0x0,0x3BC"; 		        //Float
            public const string ViewHeight = "0x02555C38,0x124,0x0,0x424";                  //Float

            //Backpack
            public const string BackpackItemsMax = "0x025438B8,0x260,0x288";	        //Int
            public const string WeaponDecks = "0x02543508,0x8,0x20,0x1C,0x28C";	        //Int
            public const string BackpackItems = "0x02543508,0x8,0x20,0x1C,0x2B4";		//Int

            //Player Ammo
            public const string RevolverAmmo = "0x02542680,98";                             //Float
            public const string RevolverAmmoMax = "0x02542680,80";                          //Float
            public const string SMGAmmo = "0x02542678,98";                                  //Float
            public const string SMGAmmoMax = "0x02542678,80";		                        //Float
            public const string CarbineAmmo = "0x02542690,0x98";                            //Float
            public const string CarbineAmmoMax = "0x02542690,0x80";		                    //Float
            public const string ShotgunShells = "0x02542670,98";                            //Float
            public const string ShotgunShellsMax = "0x02542670,80";	                        //Float
            public const string SniperRifleAmmo = "0x02542668,98";	                        //Float
            public const string SniperRifleAmmoMax = "0x02542668,80";                       //Float
            public const string Grenades = "0x025C1D90,0x50,0x280,0x98";					//Float
            public const string GrenadesMax = "0x025C1D90,0x50,0x280,0x80";                 //Float
            public const string RepeaterPistolAmmo = "0x025C1D90,0x50,0x2A0,0x98";		    //Float
            public const string RepeaterPistolMax = "0x025C1D90,0x50,0x2A0,0x80";           //Float
            public const string LauncherAmmo = "0x02542660,0x98";                           //Float
            public const string LauncherAmmoMax = "0x02542660,0x80";				        //Float

            //Weapon Proficiencies
            //XP("BorderlandsGOTY.exe"+025C4DA8,6D0,10,***) or ("BorderlandsGOTY.exe"+025C4DA8,630,10,***) || Note
            //public const string PistolLVL =
            public const string PistolCurrentXP = "0x025C4DA8,0x6D0,0x10,0xD84";		//Int
            public const string PistolRequiredXP = "0x025C4DA8,0x6D0,0x10,0xD88";	    //Int
            //public const string SMGLVL =
            public const string SMGCurrentXP = "0x025C4DA8,0x6D0,0x10,0xDA4";			//Int
            public const string SMGRequiredXP = "0x025C4DA8,0x6D0,0x10,0xDA8";			//Int
            //public const string ShotgunLVL = ???
            public const string ShotgunCurrentXP = "0x025C4DA8,0x6D0,0x10,0xD94";		//Int
            public const string ShotgunRequiredXP = "0x025C4DA8,0x6D0,0x10,0xD98";		//Int
            //public const string CarbineLVL = ???
            public const string CarbineCurrentXP = "0x025C4DA8,0x6D0,0x10,0xDB4";		//Int
            public const string CarbineRequiredXP = "0x025C4DA8,0x6D0,0x10,0xDB8";		//Int
            //public const string SniperLVL = ???
            public const string SniperCurrentXP = "0x025C4DA8,0x6D0,0x10,0xDC4";		//Int
            public const string SniperRequiredXP = "0x025C4DA8,0x6D0,0x10,0xDC8";		//Int
            //public const string LauncherLVL = ???
            public const string LauncherCurrentXP = "0x025C4DA8,0x6D0,0x10,0xDD4";		//Int
            public const string LauncherRequiredXP = "0x025C4DA8,0x6D0,0x10,0xDD8";	    //Int
            //public const string ElementalLVL = ???
            public const string ElementalCurrentXP = "0x025C4DA8,0x6D0,0x10,0xDE4";	    //Int
            public const string ElementalRequiredXP = "0x025C4DA8,0x6D0,0x10,0xDE8";	//Int

            //No Recoil Inject Attempt
            //Default Byte Array = F3 44 0F 59 A7 CC 0F 00 00 // mulss xmm12,[rdi+00000FCC]
            //New Byte Array = 45 0F 57 E4 90 90 90 90 90) // xorps xmm12,xmm12 => nop,nop,nop,nop,nop
            public const string NoRecoilInject = "0x1412B05"; //Bytes
            public const string NoRecoilAddress = "BorderlandsGOTY.exe+1412B05";
        }

        #endregion

        #region //Main Form & XP ComboBox

        public BorderlandsGOTYEnhanced()
        {
            InitializeComponent();
        }

        private void BorderlandsGOTYEnhanced_Load(object sender, EventArgs e)
        {
            int PID = m.GetProcIdFromName(BORDERLANDSPROCESS);
            if (PID > 0)
            {
                m.OpenProcess(PID);
                BLRunning = true;
                //MessageBox.Show("Connected to Game");
            }
            BLRunning = false;
            
            //XP Multiplier ComboBox Config
            XPMultiplyComboBox.Items.Clear();
            var list = new List<XP>()
            {
                new XP {ID = "01", Name = "x1"},
                new XP {ID = "02", Name = "x2"},
                new XP {ID = "03", Name = "x5"},
                new XP {ID = "04", Name = "x10"},
                new XP {ID = "05", Name = "x100"}
            };
            XPMultiplyComboBox.DataSource = list;
            XPMultiplyComboBox.ValueMember = "ID";
            XPMultiplyComboBox.DisplayMember = "Name";
        }

        private void XPMultiplyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!BLRunning)
            {
                return;
            }

            //Determine Current XP Multiplier and Display Color Indicator
            if (XPMultiplyComboBox.SelectedValue.ToString() == "01")
            {
                var defaultValue = 1;
                var XPAddress = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.XPMultiplier}");
                if (XPAddress == defaultValue)
                {
                    pnl_XPstatus.BackColor = Color.FromArgb(150, 0, 0);
                }
                else
                {
                    m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.XPMultiplier}", "float", "1");
                    pnl_XPstatus.BackColor = Color.FromArgb(150, 0, 0);
                }
            }

            ///Writes based on drop down selection
            #region

            if (XPMultiplyComboBox.SelectedValue.ToString() == "02")
            {
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.XPMultiplier}", "float", "2");
                pnl_XPstatus.BackColor = Color.FromArgb(0, 150, 0);
            }

            if (XPMultiplyComboBox.SelectedValue.ToString() == "03")
            {
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.XPMultiplier}", "float", "5");
                pnl_XPstatus.BackColor = Color.FromArgb(0, 150, 0);
            }

            if (XPMultiplyComboBox.SelectedValue.ToString() == "04")
            {
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.XPMultiplier}", "float", "10");
                pnl_XPstatus.BackColor = Color.FromArgb(0, 150, 0);

            }

            if (XPMultiplyComboBox.SelectedValue.ToString() == "05")
            {
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.XPMultiplier}", "float", "100");
                pnl_XPstatus.BackColor = Color.FromArgb(0, 150, 0);
            }

            #endregion

        }

        #endregion

        #region //Timers

        //Memory Reader
        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            //Memory.dll x64
            int PID = m.GetProcIdFromName(BORDERLANDSPROCESS);
            if (PID > 0)
            {
                m.OpenProcess(PID);
                BLRunning = true;
            }
            else
            {
                BLRunning = false;
            }
        }

        //No Clip Timer || INACTIVE ||
        private void NoClipTimer_Tick(object sender, EventArgs e)
        {
            var PlayerXPos = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.PlayerX}");
            var PlayerYPos = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.PlayerY}");
            var PlayerZPos = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.PlayerZ}");

            #region //Debug 

            //Fly (Working ... Disabled for now)
            //if (GetAsyncKeyState(Keys.Space) < 0)
            //{
            //    var newValue = PlayerZPos + 20;
            //    m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.PlayerZ}", "float", newValue.ToString());
            //}

            //if (GetAsyncKeyState(Keys.LControlKey) < 0)
            //{
            //    var newValue = PlayerZPos - 20;
            //    m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.PlayerZ}", "float", newValue.ToString());
            //}

            //if (GetAsyncKeyState(Keys.Up) < 0)
            //{
            //    var newValue = PlayerXPos + 5;
            //    m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.PlayerZ}", "float", newValue.ToString());
            //}

            //if (GetAsyncKeyState(Keys.Down) < 0)
            //{
            //    var newValue = PlayerXPos - 5;
            //    m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.PlayerZ}", "float", newValue.ToString());
            //}

            //if (GetAsyncKeyState(Keys.Left) < 0)
            //{
            //    var newValue = PlayerYPos + 5;
            //    m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.PlayerZ}", "float", newValue.ToString());
            //}

            //if (GetAsyncKeyState(Keys.Right) < 0)
            //{
            //    var newValue = PlayerYPos - 5;
            //    m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.PlayerZ}", "float", newValue.ToString());
            //}
            #endregion
        }

        //Numpad Functions
        private void HotKeyTimer_Tick(object sender, EventArgs e)
        {
            if (!BLRunning)
            {
                return;
            }

            ///Variables
            #region
            //Health and Shields
            var maxValueHealth = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.MaxHealth}");
            var maxValueShields = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.MaxShield}");

            //Max Ammo Types
            var maxValueGrenades = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.GrenadesMax}");
            var maxValueRepeater = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.RepeaterPistolMax}");
            var maxValueRevolver = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.RevolverAmmoMax}");
            var maxValueSMG = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.SMGAmmoMax}");
            var maxValueShells = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.ShotgunShellsMax}");
            var maxValueSniper = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.SniperRifleAmmoMax}");
            var maxValueLauncher = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.LauncherAmmoMax}");
            var maxValueCarbine = m.ReadFloat($"BorderlandsGOTY.exe+{Offsets.CarbineAmmoMax}");

            //Addresses we don't want to max out
            var oldMoneyValue = m.ReadInt($"BorderlandsGOTY.exe+{Offsets.Money}");
            var oldKeysValue = m.ReadInt($"BorderlandsGOTY.exe+{Offsets.GoldenKeyTotal}");
            var oldUsedKeysValue = m.ReadInt($"BorderlandsGOTY.exe+{Offsets.GoldenKeyUsed}");

            //No Recoil Stuff
            var RecoilAddress = m.ReadBytes("BorderlandsGOTY.exe+1412B05", 9);
            var DefaultRecoilValue = new byte[] { 0xF3, 0x44, 0x0F, 0x59, 0xA7, 0xCC, 0x0F, 0x00, 0x00 };

            #endregion

            ///Toggle Indicators
            #region

            if (!HealthToggled)
            {
                pnl_InfHealth.BackColor = Color.FromArgb(150, 0, 0);
            }
            
            if (!AmmoToggled)
            {
                pnl_InfAmmo.BackColor = Color.FromArgb(150, 0, 0);
            }
            
            if (!MoneyToggled)
            {
                pnl_InfMoney.BackColor = Color.FromArgb(150, 0, 0);
            }

            if (!KeysToggled)
            {
                pnl_InfKeys.BackColor = Color.FromArgb(150, 0, 0);
            }

            if (RecoilAddress.SequenceEqual(DefaultRecoilValue))
            {
                pnl_NoRecoil.BackColor = Color.FromArgb(150, 0, 0);
            }

            #endregion

            ///Toggle Keys
            #region

            //Refill Health, Shields and Ammo (NUMPAD 0) || ACTIVE ||
            if (GetAsyncKeyState(Keys.NumPad0) < 0)
            {
                //Refill Health and Shields
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.Health}", "float", maxValueHealth.ToString());
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.Shield}", "float", maxValueShields.ToString());

                //Refill All Ammo Types
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.Grenades}", "float", maxValueGrenades.ToString());
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.RepeaterPistolAmmo}", "float", maxValueRepeater.ToString());
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.RevolverAmmo}", "float", maxValueRevolver.ToString());
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.SMGAmmo}", "float", maxValueSMG.ToString());
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.ShotgunShells}", "float", maxValueShells.ToString());
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.SniperRifleAmmo}", "float", maxValueSniper.ToString());
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.LauncherAmmo}", "float", maxValueLauncher.ToString());
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.CarbineAmmo}", "float", maxValueCarbine.ToString());
            }

            //No Recoil Mod (NUMPAD 1 Toggle ON/OFF) || ACTIVE ||
            if (GetAsyncKeyState(Keys.NumPad1) < 0)
            {
                if (RecoilAddress.SequenceEqual(DefaultRecoilValue))
                {
                    //No Recoil On
                    m.WriteMemory("BorderlandsGOTY.exe+1412B05", "bytes", "45 0F 57 E4 90 90 90 90 90");
                    pnl_NoRecoil.BackColor = Color.FromArgb(0, 150, 0);
                }
                else
                {
                    m.WriteMemory("BorderlandsGOTY.exe+1412B05", "bytes", "F3 44 0F 59 A7 CC 0F 00 00");
                }

            }

            //Infinite Health and Shields (NUMPAD 2 Toggle ON/OFF) || ACTIVE ||
            if (GetAsyncKeyState(Keys.NumPad2) < 0)
            {
                HealthToggled = !HealthToggled;
                if (HealthToggled)
                {
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.Health}", "float", maxValueHealth.ToString());
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.Shield}", "float", maxValueShields.ToString());
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.SkillCooldown}", "float", "0");
                    pnl_InfHealth.BackColor = Color.FromArgb(0, 150, 0);
                }
                else
                {
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.Health}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.Shield}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.SkillCooldown}");
                }
            }

            //Infinite Ammo (NUMPAD 3 Toggle ON/OFF) || ACTIVE ||
            if (GetAsyncKeyState(Keys.NumPad3) < 0)
            {
                AmmoToggled = !AmmoToggled;
                if (AmmoToggled)
                {
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.CarbineAmmo}", "float", maxValueCarbine.ToString());
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.Grenades}", "float", maxValueGrenades.ToString());
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.RepeaterPistolAmmo}", "float", maxValueRepeater.ToString());
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.RevolverAmmo}", "float", maxValueRevolver.ToString());
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.SMGAmmo}", "float", maxValueSMG.ToString());
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.ShotgunShells}", "float", maxValueShells.ToString());
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.SniperRifleAmmo}", "float", maxValueSniper.ToString());
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.LauncherAmmo}", "float", maxValueLauncher.ToString());
                    pnl_InfAmmo.BackColor = Color.FromArgb(0, 150, 0);
                }
                else
                {
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.Grenades}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.Health}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.Shield}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.Grenades}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.RepeaterPistolAmmo}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.RevolverAmmo}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.SMGAmmo}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.ShotgunShells}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.SniperRifleAmmo}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.LauncherAmmo}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.CarbineAmmo}");
                }
            }

            //Infinite Money (NUMPAD 4 Toggle ON/OFF) || ACTIVE ||
            if (GetAsyncKeyState(Keys.NumPad4) < 0)
            {
                MoneyToggled = !MoneyToggled;
                if (MoneyToggled)
                {
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.Money}", "int", oldMoneyValue.ToString());
                    pnl_InfMoney.BackColor = Color.FromArgb(0, 150, 0);
                }
                else
                {
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.Money}");
                }
            }

            //Infinite Golden Keys
            if (GetAsyncKeyState(Keys.NumPad5) < 0)
            {
                KeysToggled = !KeysToggled;
                if (KeysToggled)
                {
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.GoldenKeyTotal}", "int", oldKeysValue.ToString());
                    m.FreezeValue($"BorderlandsGOTY.exe+{Offsets.GoldenKeyUsed}", "int", oldUsedKeysValue.ToString());
                    pnl_InfKeys.BackColor = Color.FromArgb(0, 150, 0);
                }
                else
                {
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.GoldenKeyUsed}");
                    m.UnfreezeValue($"BorderlandsGOTY.exe+{Offsets.GoldenKeyTotal}");
                }
            }
            
            #endregion

        }

        #endregion

        #region //Buttons

        //Money Button & Textbox
        private void MoneyButton_Click(object sender, EventArgs e)
        {
            if (!BLRunning)
            {
                return;
            }

            if (MoneyTextBox.Text != "")
            {
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.Money}", "int", MoneyTextBox.Text);
            }
        }

        //XP Button & Textbox
        private void XPButton_Click(object sender, EventArgs e)
        {
            if (!BLRunning)
            {
                return;
            }

            if (XPTextBox.Text != "")
            {
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.Level}", "int", XPTextBox.Text);
            }
        }

        //Golden Keys Button & Textbox
        private void KeysButton_Click(object sender, EventArgs e)
        {
            /// -----> BUG REPORT : Golden Keys
            /// Sometimes sending keys doesnt work if player modifies Golden Keys Used offset. 
            /// If sending keys does not work , and sending a value higher than keys used also does not work. Reset Golden Keys Used to 0
            /// If more people have this issue I will adjust teh code to modify golden keys used as well as golden keys given . 
            /// I think this is related to sending a fixed number of keys rather than adding to current keys total. 
            /// More testing is required and I havebeen too busy messing with No Recoil and No Clip.

            if (!BLRunning)
            {
                return;
            }

            if (KeysTextBox.Text != "")
            {
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.GoldenKeyTotal}", "int", KeysTextBox.Text);
            }
        }

        //Skill Points Button & Textbox
        private void SkillPointsButton_Click(object sender, EventArgs e)
        {
            if (!BLRunning)
            {
                return;
            }

            if (SkillpointstextBox.Text != "")
            {
                m.WriteMemory($"BorderlandsGOTY.exe+{Offsets.SkillPoints}", "int", SkillpointstextBox.Text);
            }
        }

        #endregion
    
    }
}
