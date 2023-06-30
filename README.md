# Media Player Application

The Media Player Application is a robust software that provides essential functionalities for playing audio and video files, managing media libraries, creating playlists, and interacting with the application through a command-line interface.

## Features

The media player application is a robust software that meets the requirements by providing essential functionalities:

1. Playback Functionality:

    - Play audio and video files
    - Control playback with features like play, pause, stop, and seek

2. Media Management:

    - Manage media library by adding, removing, and organizing media files
    - Create and manage playlists.

3. Command-Line Interface:

    - User-friendly command-line interface for easy navigation and interaction
    - Clear instructions and feedback to guide users through operations.

4. Error Handling:

    - Gracefully handle errors and exceptions

## Architecture

The Media Player Application is designed with a solid and clean architecture, following important software engineering principles. Here are the key architectural patterns and principles used:
* Factory Pattern:
    - Implemented the Factory pattern to create different types of media players, such as audio player and video player. This allows for easy extensibility and flexibility in adding new player types.

* Singleton Pattern:
    - Implemented the Singleton pattern to ensure there is only one instance of the media player manager throughout the application. This ensures consistent access to the manager and avoids multiple instances causing conflicts.

## Technologies Used

* C# programming language
* .NET Framework

## Installation & Usage

1. Clone the repository :
```
   https://github.com/SamAddy/Media-Player-Application.git
```
2. Navigate to the project directory
```
   cd Library-Management-System
```
3. Restore dependencies
```
   dotnet restore
```
4. Run the application 
```
   dotnet run
```

## Testing

The MediaPlayer application has a comprehensive suite of tests to ensure the correctness and robustness of its functionalities. The tests are written using Xunit, a testing framework for .NET applications.

### Unit Tests

The unit tests cover various components of the application, including the domain entities, repositories, services, and controllers. These tests verify the behavior of individual units of code in isolation to ensure they function correctly.

Key unit tests include:

* MediaFileTests: Tests the MediaFile entity and its derived classes (Audio, Video) for proper initialization and behavior.
* PlayListTests: Tests the PlayList entity for adding and removing files, emptying the list, and checking user ID validation.
* UserTests: Tests the User entity for adding and removing playlists.

### Integration Tests

The integration tests focus on testing the interaction between different components of the application, such as the service and repository layers. These tests ensure that the components work together correctly and that the application's functionalities are implemented as expected.

Key integration tests include:

* MediaServiceTests: Tests the MediaService class, which interacts with the media repository, for creating new files, deleting files, and retrieving files. 

## Structure

```
📦 dotnet-media-player-app
├─ .gitignore
├─ MediaPlayer
│  ├─ MediaPlayer.Application
│  │  ├─ MediaPlayer.Application.csproj
│  │  └─ src
│  │     ├─ MediaController.cs
│  │     ├─ PlayListController.cs
│  │     └─ UserController.cs
│  ├─ MediaPlayer.Business
│  │  ├─ MediaPlayer.Business.csproj
│  │  └─ src
│  │     ├─ Service
│  │     │  ├─ MediaService.cs
│  │     │  ├─ PlayListService.cs
│  │     │  └─ UserService.cs
│  │     └─ ServiceInterface
│  │        ├─ IMediaService.cs
│  │        ├─ IPlayListService.cs
│  │        └─ IUserService.cs
│  ├─ MediaPlayer.Domain
│  │  ├─ MediaPlayer.Domain.csproj
│  │  └─ src
│  │     ├─ Entity
│  │     │  ├─ Audio.cs
│  │     │  ├─ BaseEntity.cs
│  │     │  ├─ MediaFile.cs
│  │     │  ├─ PlayList.cs
│  │     │  ├─ User.cs
│  │     │  └─ Video.cs
│  │     ├─ Factory
│  │     │  └─ MediaFileFactory.cs
│  │     ├─ FactoryInterface
│  │     │  └─ IMediaFileFactory.cs
│  │     └─ RespositoryInterface
│  │        ├─ IMediaRepository.cs
│  │        ├─ IPlayListRepository.cs
│  │        └─ IUserRepository.cs
│  ├─ MediaPlayer.Infrastructure
│  │  ├─ MediaPlayer.Infrastructure.csproj
│  │  ├─ Program.cs
│  │  └─ Repository
│  │     ├─ MediaRepository.cs
│  │     ├─ PlayListRepository.cs
│  │     └─ UserRepository.cs
│  ├─ MediaPlayer.Tests
│  │  ├─ MediaPlayer.Tests.csproj
│  │  └─ src
│  │     ├─ Domain.Test
│  │     │  ├─ AudioTests.cs
│  │     │  ├─ Entity.Tests
│  │     │  │  ├─ AudioTests.cs
│  │     │  │  ├─ PlayListTests.cs
│  │     │  │  ├─ UserTests.cs
│  │     │  │  └─ VideoTest.cs
│  │     │  └─ VideoTest.cs
│  │     └─ Usings.cs
│  └─ MediaPlayer.sln
└─ README.md
```

