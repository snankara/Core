using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities;

public class OtpAuthenticator: Entity<Guid>
{
    public Guid UserId { get; set; }
    public byte[] SecretKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; } = null!;

    public OtpAuthenticator()
    {
        
    }

    public OtpAuthenticator(Guid userId, byte[] secretKey, bool ısVerified)
    {
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = ısVerified;
    }

    public OtpAuthenticator(Guid id, Guid userId, byte[] secretKey, bool ısVerified): base(id)
    {
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = ısVerified;
    }
}
