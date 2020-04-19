using BE;
using DAL;
using System.Threading.Tasks;


namespace BL
{
    public class BLimp
    {
        /// <summary>
        /// Returns the image sent from a specific email address
        /// </summary>
        /// <param name="from">The email from which the message should be sent</param>
        /// <param name="index">Optional, selecting another index which is not the last image</param>
        public async Task<string> GetImageFrom(string from, int index = 0)
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

        /// <summary>
        /// A function that checks whether an image is an food image or not
        /// </summary>
        /// <param name="image">Picture of a store in Base64 coding</param>
        public bool VerifyImageAsFood(string image)
        {
            return new ImageVerification().IsFood(image);
        }

        /// <summary>
        /// Receives an address and returns whether the address really exists
        /// </summary>
        /// <param name="address">The address to check</param>
        public bool VerifyAddress(Address address)
        {
            return new AddressVerification().IsRealAdrress(address);
        }

        /// <summary>
        /// A function that receives text in Hebrew and translates it into English
        /// </summary>
        /// <param name="text">The Hebrew content should be translated</param>
        /// <returns>String, translation of the content into English</returns>
        public string TranslateHEtoEN(string text)
        {
            return new TranslateText().TranslateHEtoEN(text);
        }
    }
}
