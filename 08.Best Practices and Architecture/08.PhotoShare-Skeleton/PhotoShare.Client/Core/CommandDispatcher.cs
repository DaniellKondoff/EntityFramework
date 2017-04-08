namespace PhotoShare.Client.Core
{
    using Commands;
    using Service;
    using System.Linq;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string commandName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            string result = string.Empty;

            UserService userService = new UserService();
            TownService townService = new TownService();
            TagService tagService = new TagService();
            AlbumService albumService = new AlbumService();
            PictureService pictureService = new PictureService();
            switch (commandName)
            {
                case "Exit":
                    ExitCommand exit = new ExitCommand();         
                    result=exit.Execute();
                    break;
                case "RegisterUser":
                    RegisterUserCommand registerUser = new RegisterUserCommand(userService);
                    result=registerUser.Execute(commandParameters);
                    break;
                case "AddTown":
                    AddTownCommand addTown = new AddTownCommand(townService);
                    result = addTown.Execute(commandParameters);
                    break;
                case "ModifyUser":
                    ModifyUserCommand modiftUser = new ModifyUserCommand(userService,townService);
                    result = modiftUser.Execute(commandParameters);
                    break;
                case "DeleteUser":
                    DeleteUser deleteUser = new DeleteUser(userService);
                    result = deleteUser.Execute(commandParameters);
                    break;
                case "AddTag":
                    AddTagCommand addTag = new AddTagCommand(tagService);
                    result = addTag.Execute(commandParameters);
                    break;
                case "CreateAlbum":
                    CreateAlbumCommand createAlbum = new CreateAlbumCommand(userService,tagService,albumService);
                    result = createAlbum.Execute(commandParameters);
                    break;
                case "AddTagTo":
                    AddTagToCommand addTagTo = new AddTagToCommand( tagService, albumService);
                    result = addTagTo.Execute(commandParameters);
                    break;
                case "MakeFriends":
                    MakeFriendsCommand makeFriends = new MakeFriendsCommand(userService);
                    result = makeFriends.Execute(commandParameters);
                    break;
                case "ListFriends":
                    PrintFriendsListCommand printFriends = new PrintFriendsListCommand(userService);
                    result = printFriends.Execute(commandParameters);
                    break;
                case "ShareAlbum":
                    ShareAlbumCommand shareAlbum = new ShareAlbumCommand(userService,albumService);
                    result = shareAlbum.Execute(commandParameters);
                    break;
                case "UploadPicture":
                    UploadPictureCommand uploadPicture = new UploadPictureCommand(albumService,pictureService);
                    result = uploadPicture.Execute(commandParameters);
                    break;
                case "Login":
                    LoginCommand login = new LoginCommand();
                    result = login.Execute(commandParameters);
                    break;
                case "Logout":
                    LogoutCommand logout = new LogoutCommand();
                    result = logout.Execute();
                    break;
            }
            return result;

        }
    }
}
