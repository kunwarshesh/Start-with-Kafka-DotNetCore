using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Contracts
{
    public interface IProducer
    {
        /// <summary>
        /// Produce message on given topic
        /// </summary>
        /// <param name="topic">Topic Name</param>
        /// <param name="message">Message</param>
        Task<string> PublishAsync(string topic, string message);
    }
}
