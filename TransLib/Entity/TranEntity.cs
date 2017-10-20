using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLib.Entity
{
    public class TranEntity
    {
        public TranEntity()
        { }
        //public TranEntity()
        //{ }
        private string _bTranID;
        public virtual string bTranID
        {
            get { return _bTranID; }
            set { _bTranID = value; }
        }

        private string _bTranDate;
        public string bTranDate
        {
            get { return _bTranDate; }
            set { _bTranDate = value; }
        }

        private string _bTranAmount;
        public string bTranAmount
        {
            get { return _bTranAmount; }
            set { _bTranAmount = value; }
        }

        private string _bTranCRDR;
        public string bTranCRDR
        {
            get { return _bTranCRDR; }
            set { _bTranCRDR = value; }
        }

        private string _bTranTrCode;
        public string bTranTrCode
        {
            get { return _bTranTrCode; }
            set { _bTranTrCode = value; }
        }

        private string _bTranDescRef;
        public string bTranDescRef
        {
            get { return _bTranDescRef; }
            set { _bTranDescRef = value; }
        }

        private string _bTranCreated;
        public string bTranCreated
        {
            get { return _bTranCreated; }
            set { _bTranCreated = value; }
        }

    }
}
