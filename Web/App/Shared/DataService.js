﻿import axios from 'axios';

axios.defaults.headers.common['X-CSRF-TOKEN'] = document.querySelector('meta[name="csrf-token"]').getAttribute('content');

//const baseUrl = 'http://localhost:4810/Api';

export default {
    //Login(loginName, password, secretNo) {
    //    return axios.post(baseUrl + '/security/login', { loginName, password, secretNo });
    //},
    SignupStudent(user) {
        return axios.post(`/Security/SignupStudent`, user);
    },
    loginUserAccount(user) {
        return axios.post(`/Security/loginUser`, user);
    },

    CheckLoginStatus() {
          return axios.post('/Security/checkloginstatus');
    },
    Logout() {
        return axios.post('/Security/logout');
    },    
   
    // ********************** Schools ***************************
    GetAllSchools() {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Web/Schools/GetAllSchools`);
    },
    GetStudentProfile() {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Web/StudentProfile/GetStudentProfile`);
    },
    
    updateStudent(user) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.post(`/Api/Web/StudentProfile/updateStudent`, user);
    },
    // ********************* AcademicYears ****************
    GetAllAcadimacYears() {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Web/AcadimacYears/GetAllAcadimacYears`);
    },

    GetLectures(eventId) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/web/Courses/fetchCourse?eventId=${eventId}`);
    },

    // *********************** courses ********************

    GetMySubjects(pageNo, pageSize) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Web/Courses/GetMySubjects?pageno=${pageNo}&pagesize=${pageSize}`);
    },
    // ************ Students **********

     GetStudents() {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
         return axios.get(`/Api/Web/Students/GetStudents`);
    },

    // ******************* Messages ************************

     SentMessage(Student) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
         return axios.post(`/Api/Web/Messages/SentMessage`, Student);
    },
    GetInbox(pageNo, pageSize) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Web/Messages/GetInbox?pageno=${pageNo}&pagesize=${pageSize}`);
    },
    GetSentMessage(pageNo, pageSize) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
        return axios.get(`/Api/Web/Messages/GetSentMessage?pageno=${pageNo}&pagesize=${pageSize}`);
    }

    ////********************* Student Service *****************************
    //GetStudents(pageNo, pageSize, UserType, CompanyId) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.get(baseUrl + `/Admin/Students/Get?pageno=${pageNo}&pagesize=${pageSize}&UserType=${UserType}&CompanyId=${CompanyId}`);
    //},
    //DeleteStudent(StudentId) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Students/${StudentId}/delete`);
    //},
    //AddStudent(Student) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Students/Add`, Student);
    //},
    //EditStudent(Student) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Students/Edit`, Student);
    //},
    ////******************************************* Company Service *********************************
    //GetCompanies() {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.get(baseUrl + `/Admin/Companies/Get`);
    //},
    //GetCompanies_v1(pageNo, pageSize) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.get(baseUrl + `/Admin/Companies/GetCompanies?pageno=${pageNo}&pagesize=${pageSize}`);
    //},
    //DeleteCompany(CompanyId) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Companies/${CompanyId}/delete`);
    //},
    //AddCompany(Company) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Companies/Add`, Company);
    //},
    //EditCompany(Company) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Companies/Edit`, Company);
    //},
    ////********************* Super Packages Service *****************************

    //GetSuperPackages() {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.get(baseUrl + `/Admin/SuperPackages/Get`);
    //},
    //GetSuperPackages_v1(pageNo, pageSize) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.get(baseUrl + `/Admin/SuperPackages/GetSuperPackages?pageno=${pageNo}&pagesize=${pageSize}`);
    //},
    //GetSuperPackagesContainsPackagesOnly(pageNo, pageSize) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.get(baseUrl + `/Admin/SuperPackages/GetSuperPackagesContainsPackagesOnly?pageno=${pageNo}&pagesize=${pageSize}`);
    //},
    //DeleteSuperPackage(SuperPackageId) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/SuperPackages/${SuperPackageId}/delete`);
    //},
    //AddSuperPackage(SuperPackage) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/SuperPackages/Add`, SuperPackage);
    //},
    //EditSuperPackage(SuperPackage) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/SuperPackages/Edit`, SuperPackage);
    //},
    ////************* Courses ************
    //GetCoursesBySuperPackageId(pageNo, pageSize,superPakcageId) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.get(baseUrl + `/Admin/Courses/GetCoursesBySuperPackageId?pageno=${pageNo}&pagesize=${pageSize}&SuperPackageId=${superPakcageId}`);
    //},
    //GetCoursesByPackageId(pageNo, pageSize, PakcageId) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.get(baseUrl + `/Admin/Courses/GetCoursesByPackageId?pageno=${pageNo}&pagesize=${pageSize}&PackageId=${PakcageId}`);
    //},
    //DeleteCourse(CourseId) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Courses/${CourseId}/delete`);
    //},
    //AddCourse(Course) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Courses/Add`, Course);
    //},
    //EditCourse(Course) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Courses/Edit`, Course);
    //},
    ////****************** Packages *************************
    //GetPackagesBySuperPackageId(pageNo, pageSize, superPakcageId) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.get(baseUrl + `/Admin/Packages/GetPackagesBySuperPackageId?pageno=${pageNo}&pagesize=${pageSize}&SuperPackageId=${superPakcageId}`);
    //},
    //DeletePackage(PackageId) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Packages/${PackageId}/delete`);
    //},
    //AddPackage(Package) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Packages/Add`, Package);
    //},
    //EditPackage(Package) {
        
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.post(baseUrl + `/admin/Packages/Edit`, Package);
    //},
    //GetPackages(pageNo, pageSize, superPakcageId) {
    //    axios.defaults.headers.common['Authorization'] = 'Bearer ' + document.querySelector('meta[name="api-token"]').getAttribute('content');
    //    return axios.get(baseUrl + `/Admin/Packages/GetPackages?pageno=${pageNo}&pagesize=${pageSize}&SuperPackageId=${superPakcageId}`);
    //},


}