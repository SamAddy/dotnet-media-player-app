using MediaPlayer.Application.src;
using MediaPlayer.Business.src.Service;
using MediaPlayer.Domain.src.Entity;
using MediaPlayer.Infrastructure.Repository;

internal class Program
{
    private static UserController userController;
    private static MediaController mediaController;
    private static PlayListController playListController;

    private static void Main(string[] args)
    {
        var user = User.Instance;
        var userRepository = new UserRepository();
        var userService = new UserService(userRepository);
        var userController = new UserController(userService);

        var mediaRepository = new MediaRepository();
        var mediaService = new MediaService(mediaRepository);
        var mediaController = new MediaController(mediaService);

        var playListRepository = new PlayListRepository(mediaRepository);
        var playListService = new PlayListService(playListRepository);
        var playListController = new PlayListController(playListService);

        bool isRunning = true;
        while (isRunning)
        {
            DisplayMenuOptions();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreatePlaylist();
                    break;
                case "2":
                    AddFileToPlaylist();
                    break;
                case "3":
                    ResumePlaying();
                    break;
                case "4":
                    PausePlaying();
                    break;
                case "5":
                    StopPlaying();
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    private static void DisplayMenuOptions()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create a Playlist");
        Console.WriteLine("2. Add File to Playlist");
        Console.WriteLine("3. Stop Playing");
        Console.WriteLine("4. Pause Playing");
        Console.WriteLine("5. Resume Playing");
        Console.WriteLine("0. Exit");
        Console.WriteLine();
    }

    private static string GetUserInput()
    {
        Console.Write("Enter option number: ");
        return Console.ReadLine();
    }

    private static void CreatePlaylist()
    {
        Console.WriteLine("Enter the name of the playlist:");
        string playlistName = Console.ReadLine();

        Console.WriteLine("Enter the name of the playlist:");
        int userId = Convert.ToInt32(Console.ReadLine());
        userController.AddNewList(playlistName, userId);

        Console.WriteLine($"Playlist '{playlistName}' created successfully for User ID: {userId}.");
        Console.WriteLine();
    }

    private static void AddFileToPlaylist()
    {
        Console.WriteLine("Enter the ID of the playlist:");
        int playlistId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the file name with extension (mp3 or mp4):");
        string fileName = Console.ReadLine();

        Console.WriteLine("Enter the file path:");
        string filePath = Console.ReadLine();

        Console.WriteLine("Enter the duration in seconds:");
        TimeSpan duration = TimeSpan.FromSeconds(Convert.ToDouble(Console.ReadLine()));

        MediaFile file;
        string extension = Path.GetExtension(fileName);

        if (extension == ".mp3")
        {
            file = mediaController.CreateNewFile<Audio>(fileName, filePath, duration);
        }
        else if (extension == ".mp4")
        {
            file = mediaController.CreateNewFile<Video>(fileName, filePath, duration);
        }
        else
        {
            Console.WriteLine("Invalid file extension. Only mp3 and mp4 files are supported.");
            Console.WriteLine();
            return;
        }

        playListController.AddNewFile(playlistId, file.GetId(), User.Instance.GetId());

        Console.WriteLine("File added to the playlist successfully.");
        Console.WriteLine();
    }

    private static void StopPlaying()
    {
        Console.WriteLine("Stopped playing.");
        Console.WriteLine();
    }

    private static void PausePlaying()
    {
        Console.WriteLine("Paused playing.");
        Console.WriteLine();
    }

    private static void ResumePlaying()
    {
        Console.WriteLine("Resumed playing.");
        Console.WriteLine();
    }
}