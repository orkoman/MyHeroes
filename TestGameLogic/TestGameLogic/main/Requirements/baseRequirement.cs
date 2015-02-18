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

        public baseRequirement<T> findFirstRequirement(Type reqType)
        {
            if (reqType.IsAssignableFrom(this.GetType()))
            {
                return this;
            }
            foreach (ReqOperation<T> reqAndOR in reqAndORList)
            {
                if (reqType.IsAssignableFrom(reqAndOR.Req.GetType()))
                {
                    return reqAndOR.Req;
                }
            }
            
            return null; 
        }

    }
}

