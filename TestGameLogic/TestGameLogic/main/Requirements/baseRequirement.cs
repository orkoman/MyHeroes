using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;

namespace TestGameLogic.main.Requirements
{
    
    public abstract class baseRequirement<T>
    {
        protected class ReqOperation<T1>
        {
            protected baseRequirement<T1> req;
            protected bool orOperation = true;

            public baseRequirement<T1> Req
            {
                get { return req; }
            }

            public bool OrOperation
            {
                get { return orOperation; }
            }

            public ReqOperation(baseRequirement<T1> req, bool orOperation)
            {
                this.req = req;
                this.orOperation = orOperation;
            }

        }

        protected List<ReqOperation<T>> reqAndORList = new List<ReqOperation<T>>();

        protected abstract bool check(T obj);

        public bool checkAll(T obj)
        {
            bool result = check(obj);

            foreach (ReqOperation<T> reqAndOR in reqAndORList)
            {
                if(reqAndOR.OrOperation)
                {
                    result |= reqAndOR.Req.checkAll(obj);
                }
                else
                {
                    result &= reqAndOR.Req.checkAll(obj);
                }
                
            }
            return result;
        }

        public baseRequirement<T> or(baseRequirement<T> req)
        {
            this.reqAndORList.Add(new ReqOperation<T>(req, true));
            return this;
        }

        public baseRequirement<T> and(baseRequirement<T> req)
        {
            this.reqAndORList.Add(new ReqOperation<T>(req, false));
            return this;
        }

    }
}

/*
 namespace TestGameLogic.main.Requirements
{
    public abstract class baseRequirement<T>
    {
        protected List<baseRequirement<T>> reqORList = new List<baseRequirement<T>>();
        protected List<baseRequirement<T>> reqANDList = new List<baseRequirement<T>>();

        protected abstract bool check(T obj);

        public bool checkAll(T obj)
        {
            bool result = check(obj);

            if (reqANDList.Count > 0)
            {
                foreach (baseRequirement<T> reqAND in reqANDList)
                {
                    result &= reqAND.checkAll(obj);
                }
            }

            if (!result && reqORList.Count > 0)
            {
                foreach (baseRequirement<T> reqOR in reqORList)
                {
                    if (reqOR.checkAll(obj))
                    { 
                        return true;
                    }
                }
            }

            return result;
        }

        public baseRequirement<T> or(baseRequirement<T> reqOR)
        {
            this.reqORList.Add(reqOR);
            return this;
        }

        public baseRequirement<T> and(baseRequirement<T> reqAND)
        {
            this.reqANDList.Add(reqAND);
            return this;
        }

    }
}
 */
