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
        return axios.post(baseUrl + `/admin/User/${UserId}/delteUser`);
    },

    EditUser(User) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + '/Admin/User/EditUser', User);
    },
    EditUsersProfile(User) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');

        return axios.post(baseUrl + '/Admin/User/EditUsersProfile', User);
    },
    EditParentProfile(User) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');

        return axios.post(baseUrl + '/Admin/User/EditParentProfile', User);
    },
    GetUsersByLevel(pageNo, pageSize, permissionModale) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/User/GetUsersByLevel?pageno=${pageNo}&pagesize=${pageSize}&BranchLevel=${permissionModale}`);
    },

    GetUserByBranch(pageNo, pageSize, BrancheModel) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/User/GetUsersByBranch?pageno=${pageNo}&pagesize=${pageSize}&BrancId=${BrancheModel}`);
    },

    GetUsers(pageNo, pageSize, UserType, id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/User/getUser?pageno=${pageNo}&pagesize=${pageSize}&UserType=${UserType}&id=${id}`);
    },

    getUserName(UserType) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/User/getUserName?UserType=${UserType}`);
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

    getShapterName(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/getShapterName?id=${id}`);
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

    AddStudentToFathter(student) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Students/AddStudentToFathter`, student);
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
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/GetSkedjuleInfo?EventId=${id}`);
    },

    delteSkedjule(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/${id}/delteSkedjule`);
    },

    GetYearsInfo(pageNo, pageSize) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/GetYearsInfo?pageno=${pageNo}&pagesize=${pageSize}`);
    },

    deleteYears(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/${id}/deleteYears`);
    },

    edityearName(form) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/edityearName`, form);
    },

    addyearName(form) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/addyearName`, form);
    },

    getyearName() {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/getyearName`);
    },

    GetSubjectInfo(pageNo, pageSize,id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/GetSubjectInfo?pageno=${pageNo}&pagesize=${pageSize}&id=${id}`);
    },

    editShpter(form) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/editShpter`, form);
    },

    editsubjectname(form) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/editsubjectname`, form);
    },

    deleteSubject(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/${id}/deleteSubject`);
    },

    addSubject(form) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/addSubject`, form);
    },

    addShapter(form) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/addShapter`, form);
    },

    GetStudentbyParent(pageNo, pageSize, id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Students/GetStudentbyParent?pageno=${pageNo}&pagesize=${pageSize}&id=${id}`);
    },

    getDetals() {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/getDetals`);
    },

    serachStudent(item) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Students/serachStudent?item=${item}`);
    },

    Getdegrees(pageNo, pageSize) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Students/Getdegrees?pageno=${pageNo}&pagesize=${pageSize}`);
    },

    UploadDegregesImage(obj) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + '/Admin/Students/UploadDegregesImage', obj);
    },

    deltedegrees(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Students/${id}/deltedegrees`);
    },

    AddNotifi(notifi) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/Admin/Notifi/AddNotifi`, notifi);
    },

    GetNotifi(pageNo, pageSize) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Notifi/GetNotifi?pageno=${pageNo}&pagesize=${pageSize}`);
    },

    AddUserNotifi(notifi) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/Admin/Notifi/AddUserNotifi`, notifi);
    },

    getShpater(pageNo, pageSize, SubjectSelected) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/getShpater?pageno=${pageNo}&pagesize=${pageSize}&subjectId=${SubjectSelected}`);
    },

    delteShpter(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/${id}/delteShpter`);
    },

    addPost(obj) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + '/Admin/Courses/addPost', obj);
    },

    GetAds(pageNo, pageSize) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/GetAds?pageno=${pageNo}&pagesize=${pageSize}`);
    },

    deleteAds(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/${id}/deleteAds`);
    },

    addExam(obj) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + '/Admin/Courses/addExam', obj);
    },

    GetExamingInfo(pageNo, pageSize) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/GetExamingInfo?pageno=${pageNo}&pagesize=${pageSize}`);
    },

    DeleteExaming(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/${id}/DeleteExaming`);
    },

    getLectures(pageNo, pageSize,id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Courses/getLectures?pageno=${pageNo}&pagesize=${pageSize}&id=${id}`);
    },

    deletelecture(id) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/${id}/deletelecture`);
    },

    addLecture(form) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Courses/addLecture`, form);
    },
    //********************** permission **************************

    GetPermissionsInfo(pageNo, pageSize) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Permission/GetPermissionsInfo?pageno=${pageNo}&pagesize=${pageSize}`);
    },
    addPermissionName(form) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(baseUrl + `/admin/Permission/addPermissionName`, form);
    },
    IsPermissin(permission) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(baseUrl + `/admin/Permission/IsPermissin?perimm=${permission}`);
    },
    //deleteYears(id) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Courses/${id}/deleteYears`);
    //},
}