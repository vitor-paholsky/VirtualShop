using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Commands.Contracts;

namespace VirtualShop.Domain.Commands;

public class CommandResult : ICommandResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

    public CommandResult(bool success, string message, object data)
    {
       Success = success;
       Message = message;
       Data = data;
    }

    public CommandResult()
    {
    }
}

