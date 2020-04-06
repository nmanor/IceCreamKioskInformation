using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BL
{
    public class BLimp
    {
        /// <summary>
        /// Returns the image sent from a specific email address
        /// </summary>
        /// <param name="from">The email from which the message should be sent</param>
        /// <param name="index">Optional, selecting another index which is not the last image</param>
        /// <returns></returns>
        public async Task<string> getImageFrom(string from, int index = 0)
        {
            GetImageFromMail getImage = new GetImageFromMail();
            string image = await getImage.getImageFrom(from, index);
            return image;
        }

        public async Task<bool> ValidateAddress(string address)
        {
            AddressValidation validation = new AddressValidation();
            return await validation.ValidateAddress(address);
        }
    }
}
