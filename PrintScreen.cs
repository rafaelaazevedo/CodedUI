 public static void PrintScreen(string _stringMessage, Boolean FULLSCREEN = false, Boolean FAIL = false)
        {
            string stringPath = "YOUR PATH"
            int _intFAIL;
            Thread.Sleep(2000);
            if ((FULLSCREEN == false))
            {
                Keyboard.SendKeys("{PrintScreen}", ModifierKeys.Alt);
                //SendKeys.SendWait("{PRTSC 2}");
            }
            else
            {
                Keyboard.SendKeys("{PrintScreen}", ModifierKeys.None);
                //SendKeys.SendWait("{PRTSC}");
            }

            DateTime x = DateTime.Now;
            string date = x.ToString().Replace("/", "").Replace(":", "").Replace(" ", "_") + ".jpg";

            Boolean _booleanSalvedPrint = false;
            while (_booleanSalvedPrint == false)
            {
                try
                {
                    Clipboard.GetImage().Save(stringPath + date);
                    _booleanSalvedPrint = true;
                }
                catch { }
            }

            Clipboard.Clear();



            if (FAIL == true)
            {
                _intFAIL = 1;
                _stringMessage = "FAIL - " + _stringMessage;
            }
            else
            {
                _intFAIL = 0;
            }

            dateAccess dateAccessBancoDadosDB = PublicFunctions.OpenDB(Values);

            dateAccessBancoDadosDB.Execute("INSERT INTO ResultExecution(IDScreen,Scenario,SCREEN,DESCRIPTION,PathPRINT,FAIL)" +
            "VALUES ('" + Values.intIDExecution + "','" + Values.stringTableCase + "','" + Values.stringTableName + "','" + _stringMessage + "','" + Values.stringPath + date + "','" + _intFAIL + "')");

           }
