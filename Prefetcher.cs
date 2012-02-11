using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SaysWho
{
    public class Prefetcher
    {
        private Thread prefetchThread;
        private List<FbUser> fbUsers;
        private Queue<GameQuestion> questions;
        private Queue<string> usedUpQuestions;

        public Prefetcher()
        {
            prefetchThread = new Thread(new ThreadStart(PrefetchProcess));
            fbUsers = new List<FbUser>();
            questions = new Queue<GameQuestion>();
        }

        public static Prefetcher TheOnlyPrefetcher { get; set; }

        const int PREFETCH_LOW_COUNT = 5;
        const int PREFETCH_UP_TO = 10;

        private void PrefetchProcess()
        {
            try
            {
                while (questions.Count < PREFETCH_UP_TO)
                {
                    
                }
            }
            catch (ThreadAbortException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }

        private void ClearUnusedUsers()
        {
            List<FbUser> fbUsers_ = new List<FbUser>(fbUsers);
            foreach (FbUser u in fbUsers_)
            {
                if (questions.FirstOrDefault(i => i.Poster.ID == u.ID) == null)
                {
                    fbUsers.Remove(u);
                }
            }
        }

        public void ClearAll()
        {
            
        }

        public GameQuestion GetNext()
        {
            if (questions.Count < PREFETCH_LOW_COUNT)
            {
                prefetchThread.Start();
            }

            return questions.Count > 0 ? questions.Dequeue() : null;
        }
    }
}
