using System.Collections.Generic;

namespace Observer
{
    public class Subject : ISubject
    {
        List<IObserver> observers;
        int observerId = 0;
        
        public void AddObserver(IObserver addObserver)
        {
            if( observers == null )
            {
                observers = new List<IObserver>();
                observerId = 0;
            }

            addObserver.ID = observerId++;
            observers.Add( addObserver );
            observers.Sort( ComparePriority );
        }
        
        int ComparePriority(IObserver a, IObserver b)
        {
            return a.Priority.CompareTo( b.Priority );
        }
        
        public void RemoveObserver(IObserver removeObserver)
        {
            IObserver observer;
            for( int i = observers.Count - 1; i >= 0; i-- )
            {
                observer = observers[i];
                if( observer.ID.Equals( removeObserver.ID ) )
                {
                    observers.RemoveAt( i );
                }
            }
        }
        
        public void OnNotify()
        {
            if( observers != null )
            {
                IObserver obserber;
                for( int i = 0, icount = observers.Count; i < icount; i++ )
                {
                    obserber = observers[i];
                    if( obserber != null )
                    {
                        obserber.OnResponse( this );
                    }
                }
            }
        }
        
        public void OnClear()
        {
            if( observers != null )
            {
                observers.Clear();
            }
            observers = null;
            observerId = 0;
        }
    }
}
