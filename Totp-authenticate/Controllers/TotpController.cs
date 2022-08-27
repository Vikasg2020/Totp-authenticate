using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtpNet;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Totp_authenticate.DB_model;
using Totp_authenticate.Otp;
using Totp_authenticate.Users;

namespace Totp_authenticate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotpController : ControllerBase
    {
         
        private readonly Iuser _db;


        public TotpController(Iuser db)
        {
              _db = db;
        }

        [HttpPost]
        [Route("generateKey")]

        public string GenerateOtp(string email)
        {
            var secretKey = EncodingKey.ToBytes("ff3ue");
            var totp = new OtpG(secretKey);
            var otp = totp.ComputeTotp();

            var verifyUser=_db.getUser(email);  

            if(verifyUser == null)
            {
                return "Invalid User";
            }


            return otp.ToString();

        }

        [HttpPost]
        [Route("validOTP")]
        public IActionResult ValidOtp( string email, string votp)
        {
            var secretKey = EncodingKey.ToBytes("ff3ue");
            var totp = new OtpG(secretKey);
            var otp = totp.ComputeTotp();

            var verifyUser = _db.getUser(email);

            if (verifyUser == null)
            {
                return BadRequest("Invalid User");
            }
            else if(votp == otp)
            { 
                    return Ok("User Valid");
                
            } 
            return BadRequest("bad request");
        }

  

        //public async Task<string> GenerateToken(User user)
        //{
        //    var signingCredentials = GetSigningCredentials();
        //    var claims = await GetClaims(user);
        //    var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        //    var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //    return token;
        //}


        //public string getnerateOTP(long n)
        //{


        //}



        //public static byte[] GenerateRandomKey(OtpHashMode mode = OtpHashMode.Sha1)
        //{
        //    return GenerateRandomKey(LengthForMode(mode));
        //}


    }
}
