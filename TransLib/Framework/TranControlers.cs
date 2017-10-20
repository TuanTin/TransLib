using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TransLib.Entity;

namespace TransLib.Framework
{
    public class TranControlers
    {
        public TranEntity ReadFile(string _pathFile)
        {
            TranEntity objbTran = null;
            try
            {
                int recordTpye = 0;
                string record = "";
                string btranID = "";
                //read file 
                string[] line = System.IO.File.ReadAllLines(_pathFile);
                //read file to row
                int iRecord = 0;

                objbTran = new TranEntity();

                foreach (string iline in line)
                {
                    /*
                     * Record file
                     * 0 : File header 
                     * 1 : Batch header
                     * 2 : Transaction detail
                     * 7 : Batch trailer
                     * 9 : File trailer
                     */
                    
                    recordTpye = int.Parse( iline.Substring(0,1));
                    if (recordTpye != 0 && recordTpye != 9)
                    {
                        iRecord = iRecord + 1;
                        string tmp = "00000000"+ iRecord.ToString();
                        btranID = "BID" + tmp.PadRight(8);
                        record = iline.Substring(38, iline.Length - 38);

                        objbTran.bTranID = btranID;
                        objbTran.bTranDate = record.Substring(0, 10).Trim();

                        int iCR = record.IndexOf("CR");
                        int iDR = record.IndexOf("DR");
                        if ( iCR > 0)
                        {
                            objbTran.bTranAmount = record.Substring(10, iCR - 10);
                            objbTran.bTranCRDR = record.Substring(iCR, 2);
                            if (iCR + 2 != record.Length - 1)
                            {
                                objbTran.bTranTrCode = record.Substring(iCR + 2, 2);
                                objbTran.bTranDescRef = record.Substring(iCR + 4, record.Length - iCR -5);
                            }
                            else
                            {
                                objbTran.bTranTrCode = record.Substring(iCR + 2, 2);
                                objbTran.bTranDescRef = record.Substring(iCR + 4, record.Length - iCR - 5);
                                
                            }
                            objbTran.bTranCreated =  DateTime.Now.ToShortDateString();
                        }
                        else if ( iDR> 0)
                        {
                            objbTran.bTranAmount = record.Substring(10, iDR - 10);
                            objbTran.bTranCRDR = record.Substring(iDR, 2);
                            if (iDR + 2 != record.Length - 1)
                            {
                                objbTran.bTranTrCode = record.Substring(iDR + 2, 2);
                                objbTran.bTranDescRef = record.Substring(iDR + 4, record.Length - iDR - 5);
                            }
                            else
                            {
                                objbTran.bTranTrCode = record.Substring(iDR + 2, 2);
                                objbTran.bTranDescRef = record.Substring(iDR + 4, record.Length - iDR - 5);

                            }
                            objbTran.bTranCreated = DateTime.Now.ToShortDateString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return objbTran;
        }
    }
}
