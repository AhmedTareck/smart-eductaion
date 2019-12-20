import axios from 'axios';
const baseUrl = '/Api';
const userUrl = '/';

axios.defaults.headers.common['X-CSRF-TOKEN'] = document.querySelector('meta[name="csrf-token"]').getAttribute('content');



export default {
    Login(loginName, password, secretNo) {
        return axios.post(baseUrl + '/security/login', { loginName, password, secretNo });
    },
    Logout() {
        return axios.post(baseUrl + '/security/logout');
    },    
    //CheckLoginStatus() {
    //    return axios.post('/security/checkloginstatus');
    //},  

    GetLoginInfo() {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/Admin/User/GetLoginInfo`);
    },
    logout(user) {
        return axios.post(`/Security/Logout`);
    },

    AddUser(User) {
     

        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + '/Admin/User/AddUser', User);
    },
    ActivateUser(UserId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/User/${UserId}/Activate`);
    },
    DeactivateUser(UserId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/User/${UserId}/Deactivate`);
    },

    DeleteUser(UserId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/User/${UserId}/delete`);
    },

    EditUser(User) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        console.log(User);
        return axios.post(baseUrl + '/Admin/User/EditUser', User);
    },
    EditUsersProfile(User) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');

        return axios.post(baseUrl + '/Admin/User/EditUsersProfile', User);
    },
    GetUsersByLevel(pageNo, pageSize, permissionModale) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/User/GetUsersByLevel?pageno=${pageNo}&pagesize=${pageSize}&BranchLevel=${permissionModale}`);
    },

    GetUserByBranch(pageNo, pageSize, BrancheModel) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/User/GetUsersByBranch?pageno=${pageNo}&pagesize=${pageSize}&BrancId=${BrancheModel}`);
    },

    GetUsers(pageNo, pageSize, UserType) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/User/GetUsers?pageno=${pageNo}&pagesize=${pageSize}&UserType=${UserType}`);
    },

    UploadImage(obj) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + '/Admin/User/UploadImage', obj);
    },

    ChangePassword(userPassword) {
        return axios.post(`/Security/ChangePassword`, userPassword);
    },


    //*******************************************  Add Message Type Service *********************************
    GetMessageTypes(pageNo, pageSize) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Admin/MessageTypes/Get?pageno=${pageNo}&pagesize=${pageSize}`);
    },
    AddMessageType(MessageTypes) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/Api/Admin/MessageTypes/Add`, MessageTypes);
    },
    EditMessageType(MessageTypes) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/Api/Admin/MessageTypes/Edit`, MessageTypes);
    },
    
    DeleteMessageType(MessageTypeId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/Api/Admin/MessageTypes/${MessageTypeId}/delete`);
    },

    //*******************************************  Branches Service *********************************
    GetBranches(pageNo, pageSize, permissionModale) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Admin/Branches/Get?pageno=${pageNo}&pagesize=${pageSize}&BranchLevel=${permissionModale}`);
    },
    GetBranchsV1() {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Admin/Branches/GetBranchs`);
    },
  
    DeleteBranch(BracnhId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/Api/Admin/Branches/${BracnhId}/delete`);
    },
    AddBranches(Branch) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/Api/Admin/Branches/Add`, Branch);
    },
    

    EditBranches(Branch) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/Api/Admin/Branches/Edit`, Branch);
    },


    IsFavorate(isFavorate, conversationId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Messages/EnabelDisplayFavorate?isFavorate=${isFavorate}&conversationId=${conversationId}`);
    },
    SetArchaveInbox(setArchive, conversationId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Messages/Archive?isArchive=${setArchive}&conversationId=${conversationId}`);
    },
    DeleteInbox(isDelete, conversationId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Messages/DeleteConversation?isDelete=${isDelete}&conversationId=${conversationId}`);
    },
    ReadUnReadInbox(isReadUnRead, conversationId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Messages/ReadUnReadInbox?isReadUnRead=${isReadUnRead}&conversationId=${conversationId}`);
    },
    GetContentInbox(conversationId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Messages/getContentConversation?conversationId=${conversationId}`);
    },
    GetMessages() {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/api/admin/Messages/GetMessages`);
    },
    GetControlMessages(pageNo, pageSize) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Admin/Messages/GetControlMessages?pageNo=${pageNo}&pageSize=${pageSize}`);
    },
    GetAllUsers(UserType) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/NewMessage/GetAllUsers?UserType=${UserType}`);
    },
    GetAllMessageTypes() {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/NewMessage/GetAllMessageTypes`);
    },
    NewMessage(NewMessage) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/Api/NewMessage/NewMessage`, NewMessage);
    },
   EditMessage(NewMessage) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
       return axios.post(`/Api/NewMessage/EditMessage`, NewMessage);
    },
    ReplayMessages(replayMessages) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/Api/Messages/ReplayMessages`, replayMessages);
    },
    downloadFile(fileId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios({
            url: `/Api/NewMessage/DownLoadFile?attachmentId=${fileId}`,
            method: 'GET',
            responseType: 'blob',
        });
    },
    FilterInbox(page, pageSize, messageTypeFilter, filterType, inputMessgeText) {
 
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Messages/getMessageFilter?page=${page}&pagesize=${pageSize}&messageTypeFilter=${messageTypeFilter}&filterType=${filterType}&inputMessgeText=${inputMessgeText}`);
    },

    GetBranchesByLevel(BranchLevel) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Admin/Branches/GetBranchesByLevel?branchLevel=${BranchLevel}`);
    },

    GetReceivedMassage(pageNo, pageSize,operateion)
    {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Admin/Messages/GetReceivedMassage?pageNo=${pageNo}&pageSize=${pageSize}&operateion=${operateion}`);
    },

    ChangeMassageState(ParticipationsId,status) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/api/admin/Messages/ChangeMassageState?ParticipationsId=${ParticipationsId}&status=${status}`);
    },

    DeleteMassage(ParticipationsId,removeFromTrash) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/api/admin/Messages/DeleteMassage?ParticipationsId=${ParticipationsId}&removeFromTrash=${removeFromTrash}`);
    },

    GetReplayes(pageNo, pageSize,conversationId)
    {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Admin/Messages/GetReplayes?pageNo=${pageNo}&pageSize=${pageSize}&conversationId=${conversationId}`);
    },

    GetCountInfo()
    {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Admin/Messages/GetCountInfo`);
    },

    AddReplay(conversationId,ReplayBody) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/api/admin/Messages/AddReplay?conversationId=${conversationId}&ReplayBody=${ReplayBody}`);
    },

    
}