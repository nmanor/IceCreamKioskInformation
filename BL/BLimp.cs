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
        public async Task<string> getImageFrom(string from, int index = 0)
        {
            GetImageFromMail getImage = new GetImageFromMail();
            string image = await getImage.getImageFrom(from, index);
            return image;
        }

        /// <summary>
        /// A function that checks whether an image is an ice cream shop image or not
        /// </summary>
        /// <param name="image">Picture of a store in Base64 coding</param>
        public bool VerifyImageAsStore(string image)
        {
            return new ImageVerification().IsShop(image);
        }
    }
}
