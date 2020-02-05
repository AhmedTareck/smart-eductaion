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

    

    GetStudent(pageNo, pageSize,EventSelectd) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Students/Get?pageno=${pageNo}&pagesize=${pageSize}&EventId=${EventSelectd}`);
    },

    GetYears() {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/Get`);
    },

    GetEvents(yearId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/GetEvents?yearId=${yearId}`);
    },

    getSubject(yearId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/getSubject?yearId=${yearId}`);
    },

    getSubjectExama(SubjectSelected) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/getSubjectExama?id=${SubjectSelected}`);
    },

    AddStudent(student) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Students/Add`, student);
    },

    delteStudent(id)
    {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Students/${id}/delteStudent`);
    },

    GetStudentByEvent(EventId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Students/GetStudentByEvent?EventId=${EventId}`);
    },

    getStudentById(studentId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Students/getStudentById?id=${studentId}`);
    },

    EditStudent(student) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Students/Edit`, student);
    },

    GetPresness(pageNo, pageSize, EventSelectd) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Presness/GetPresness?pageno=${pageNo}&pagesize=${pageSize}&EventId=${EventSelectd}`);
    },

    addPresness(presness) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Presness/Add`, presness);
    },

    deltePresness(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Presness/${id}/deltePresness`);
    },

    GetPresnessInfo(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Presness/GetPresnessInfo?id=${id}`);
    },

    editPresness(presness) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Presness/editPresness`, presness);
    },

    GetHomeWorck(pageNo, pageSize, YearSelected,EventSelectd) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/HomeWorck/GetHomeWorck?pageno=${pageNo}&pagesize=${pageSize}&YearId=${YearSelected}&eventId=${EventSelectd}`);
    },

    AddHomeWorck(selectedHomeWorck) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/HomeWorck/Add`, selectedHomeWorck);
    },

    editHomeWorck(selectedHomeWorck) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/HomeWorck/Edit`, selectedHomeWorck);
    },

    delteHomeWorck(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/HomeWorck/${id}/delteHomeWorck`);
    },

    GetExams(pageNo, pageSize, YearSelected, EventSelectd) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Exam/GetExams?pageno=${pageNo}&pagesize=${pageSize}&YearId=${YearSelected}&eventId=${EventSelectd}`);
    },

    AddExam(selectedExams) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Exam/Add`, selectedExams);
    },

    editExam (selectedExam) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Exam/Edit`, selectedExam);
    },

    delteExams(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Exam/${id}/delteExams`);
    },

    addGrids(presness) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Exam/addGrids`, presness);
    },

    getGridsInfo(pageNo, pageSize,id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Exam/getGridsInfo?pageno=${pageNo}&pagesize=${pageSize}&id=${id}`);
    },

    AddSkedjule(skedjule) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/AddSkedjule`, skedjule);
    },

    GetSkedjules(pageNo, pageSize, EventSelectd) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/GetSkedjules?pageno=${pageNo}&pagesize=${pageSize}&EventId=${EventSelectd}`);
    },

    GetSkedjuleInfo(id) {
        debugger
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/GetSkedjuleInfo?EventId=${id}`);
    },
    
}