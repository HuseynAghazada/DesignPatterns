namespace BridgeDP
{
    public class Song
    {
        private string name;
        private string lyrics;
        public Song(string name, string lyrics)
        {
            this.name = name;
            this.lyrics = lyrics;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetLyrics()
        {
            return this.lyrics;
        }
    }
    public abstract class Device
    {
        protected MusicPlayer musicPlayer;
        protected AudioPlayer audioPlayer;
        public Device(MusicPlayer musicPlayer, AudioPlayer audioPlayer)
        {
            this.musicPlayer = musicPlayer;
            this.audioPlayer = audioPlayer;
        }
        public void PlaySong(Song song)
        {
            string lyrics = this.musicPlayer.PlayMusic(song);
            this.audioPlayer.PlayAudio(lyrics);
        }
    }
    public class Phone : Device
    {
        public Phone(MusicPlayer musicPlayer, AudioPlayer audioPlayer) : base(musicPlayer, audioPlayer)
        {}
    }
    public class Computer : Device
    {
        public Computer(MusicPlayer musicPlayer, AudioPlayer audioPlayer) : base(musicPlayer, audioPlayer)
        {}
    }
    public interface MusicPlayer
    {
        public string PlayMusic(Song song);
    }
    public interface AudioPlayer
    {
        public void PlayAudio(string song);
    }
    public class Spotify : MusicPlayer
    {
        public string PlayMusic(Song song)
        {
            System.Console.WriteLine($"Spotify plays {song.GetName()} music");
            return song.GetLyrics();
        }
    }
    public class Headphones : AudioPlayer
    {
        public void PlayAudio(string song)
        {
            System.Console.WriteLine($"Headphones play this ---> {song}");
        }
    }
}