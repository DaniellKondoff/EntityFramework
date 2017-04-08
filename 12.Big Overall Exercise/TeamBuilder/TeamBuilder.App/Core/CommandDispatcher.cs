using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Core.Commands;

namespace TeamBuilder.App.Core
{
    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty;

            string[] inputArgs = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string CommandName = inputArgs.Length > 0 ? inputArgs[0] : string.Empty;
            inputArgs = inputArgs.Skip(1).ToArray();

            switch (CommandName)
            {
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    result = exit.Execute(inputArgs);
                    break;
                case "RegisterUser":
                    RegisterUserCommand registerUser = new RegisterUserCommand();
                    result = registerUser.Execute(inputArgs);
                    break;
                case "Login":
                    LoginCommand login = new LoginCommand();
                    result = login.Exute(inputArgs);
                    break;
                case "Logout":
                    LogutCommand logout = new LogutCommand();
                    result = logout.Execute(inputArgs);
                    break;
                case "DeleteUser":
                    DeleteUserCommand deleteUser = new DeleteUserCommand();
                    result = deleteUser.Execute(inputArgs);
                    break;
                case "CreateEvent":
                    CreateEventCommand createEvent = new CreateEventCommand();
                    result = createEvent.Execute(inputArgs);
                    break;
                case "CreateTeam":
                    CreateTeamCommand createTeam = new CreateTeamCommand();
                    result = createTeam.Execute(inputArgs);
                    break;
                case "InviteToTeam":
                    InveteToTeamCommand inviteTeam = new InveteToTeamCommand();
                    result = inviteTeam.Execute(inputArgs);
                    break;
                case "AcceptInvite":
                    AcceptInviteCommand acceptInvite = new AcceptInviteCommand();
                    result = acceptInvite.Execute(inputArgs);
                    break;
                case "DeclineInvite":
                    DeclineInviteCommand declineInvite = new DeclineInviteCommand();
                    result = declineInvite.Execute(inputArgs);
                    break;
                case "KickMember":
                    KickMemberCommand kickMember = new KickMemberCommand();
                    result = kickMember.Execute(inputArgs);
                    break;
                case "Disband":
                    DisbandCommand disband = new DisbandCommand();
                    result = disband.Execute(inputArgs);
                    break;
                case "AddTeamTo":
                    AddTeamToCommand addteam = new AddTeamToCommand();
                    result = addteam.Execute(inputArgs);
                    break;
                case "ShowEvent":
                    ShowEventCommand showEvent = new ShowEventCommand();
                    result = showEvent.Execute(inputArgs);
                    break;
                case "ShowTeam":
                    ShowTeamCommand showTeam = new ShowTeamCommand();
                    result = showTeam.Execute(inputArgs);
                    break;
                case "ImportUsers":
                    ImportUsersCommand importUsers = new ImportUsersCommand();
                    result = importUsers.Execute(inputArgs);
                    break;
                case "ImportTeams":
                    ImportTeamsCommand importTeams = new ImportTeamsCommand();
                    result = importTeams.Execute(inputArgs);
                    break;
                case "ExportTeam":
                    ExportTeamCommand exportTeam = new ExportTeamCommand();
                    result = exportTeam.Execute(inputArgs);
                    break;
                default:
                    throw new NotSupportedException($"Command {CommandName} not supported");
            }

            return result;
        }
    }
}
