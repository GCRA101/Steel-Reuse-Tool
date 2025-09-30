using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.controller
{
    public class SoundManager : AudioManagerInterface
    {
        //ATTRIBUTES
        private static SoundManager instance;
        private Boolean active = true;

        //CONSTRUCTOR - Private
        private SoundManager() { }

        //STATIC METHOD .getInstance()
        public static SoundManager getInstance()
        {
            if (instance == null) { instance = new SoundManager(); }
            return instance;
        }

        // METHODS

        /* Play Method - Overloaded

	    Overloaded play method taking the enum sound as input and calling within it the play method implemented from
	    the AudioManagerInterface interface that is turned into private in order to keep it hidden from the client.
	    This allows the client to input just the Sound Enum rather than its filepath, leaving it getting retrieved under
	    the hood by the Static Class SoundPathRetriever.
	    This makes the clode cleaner and easier to extend. */
        public void play(Sound sound)
        {
            // Get the file path corresponding to the input Sound enum value
            String resourceName = SoundPathRetriever.getPath(sound);

            // Get the stream for the embedded resource
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);

            if (stream == null) { throw new FileNotFoundException("The specified resource was not found.", resourceName); }

            // Play the sound
            SoundPlayer player = new SoundPlayer(stream);
            player.Play();
        }

        public void play(string filePath)
        {
            throw new NotImplementedException();
        }

        public bool isActive(){return this.active;}
        public void setActive(bool active){this.active=active;}


    }
}
