using IDrobeAPI.Application.Models.Mails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Interfaces.IMails;

public interface IMailService
{
    void SendMail(Mail mail);
}
