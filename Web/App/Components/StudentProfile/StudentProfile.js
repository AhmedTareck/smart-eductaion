import moment from "moment";
import swal from "sweetalert";
export default {
    name: "SignUp",
    components: {},
    created() {
        // this.GetAllSchools();
        // this.GetAllAcadimacYears();
        this.GetStudentProfile();
    },
    data() {
        return {
            imageData: "/assets/img/placeholder.jpg",
            AcadimacYears: [],
            Students: [],
            ConfirmPassword: "",
            photo: "",
            success: {
                confirmButtonText: "OK",
                type: "success",
                dangerouslyUseHTMLString: true,
                center: true
            },
            error: {
                confirmButtonText: "OK",
                type: "error",
                dangerouslyUseHTMLString: true,
                center: true
            },
            warning: {
                confirmButtonText: "OK",
                type: "warning",
                dangerouslyUseHTMLString: true,
                center: true
            },
            ruleForm: {
                FirstName: "",
                FatherName: "",
                GrandFatherName: "",
                SurName: "",
                MatherName: "",
                BirthDate: "",
                NID: "",
                Address: "",
                Phone: "",
                Gender: "",
                SchoolId: "",
                AcadimecYearId: "",
                photo: "",
                Image: "",
                LoginName: "",
                Email: "",
                Password: ""
            },
            rules: {
                FirstName: [
                    {
                        required: true,
                        message: "الرجاء إدخال الاسم",
                        trigger: "blur"
                    },
                    {
                        min: 2,
                        max: 20,
                        message: "يجب ان يكون طول الإسم من 2 الي 20 الحرف",
                        trigger: "blur"
                    }
                ],
                FatherName: [
                    {
                        required: true,
                        message: "الرجاء إدخال إسم الأب",
                        trigger: "blur"
                    },
                    {
                        min: 2,
                        max: 20,
                        message: "يجب ان يكون طول الإسم من 2 الي 20 الحرف",
                        trigger: "blur"
                    }
                ],
                GrandFatherName: [
                    {
                        required: true,
                        message: "الرجاء إدخال إسم الجد",
                        trigger: "blur"
                    },
                    {
                        min: 2,
                        max: 20,
                        message: "يجب ان يكون طول الإسم من 2 الي 20 الحرف",
                        trigger: "blur"
                    }
                ],
                SurName: [
                    {
                        required: true,
                        message: "الرجاء إدخال اللقب",
                        trigger: "blur"
                    },
                    {
                        min: 2,
                        max: 20,
                        message: "يجب ان يكون طول اللقب من 2 الي 20 الحرف",
                        trigger: "blur"
                    }
                ],
                MatherName: [
                    {
                        required: true,
                        message: "الرجاء إدخال اسم الام",
                        trigger: "blur"
                    },
                    {
                        min: 2,
                        max: 20,
                        message: "يجب ان يكون طول اسم الام من 2 الي 20 الحرف",
                        trigger: "blur"
                    }
                ],
                NID: [
                    {
                        required: true,
                        message: "الرجاء إدخال الرقم الوطني",
                        trigger: "blur"
                    },
                    {
                        min: 11,
                        max: 12,
                        message: "يجب ان يكون طول الرقم الوطني  12 الرقم ",
                        trigger: "blur"
                    }
                ],
                Address: [
                    {
                        required: true,
                        message: "الرجاء إدخال العنوان",
                        trigger: "blur"
                    },
                    {
                        min: 2,
                        max: 13,
                        message: "يجب ان يكون طول العنوان من 2 الي 13 الحرف",
                        trigger: "blur"
                    }
                ],
                Phone: [
                    {
                        required: true,
                        message: "الرجاء إدخال رقم الهاتف",
                        trigger: "blur"
                    },
                    {
                        min: 2,
                        max: 13,
                        message: "يجب ان يكون طول رقم الهاتف من 2 الي 13 الحرف",
                        trigger: "blur"
                    }
                ],
                BirthDate: [
                    {
                        type: "date",
                        required: true,
                        message: "الرجاء إختيار تاريخ الميلاد",
                        trigger: "change"
                    }
                ],

                LoginName: [
                    {
                        required: true,
                        message: "الرجاء إدخال اسم الستخدم",
                        trigger: "blur"
                    },
                    {
                        min: 5,
                        max: 35,
                        message:
                            "يجب ان يكون طول اسم الستخدم من 5 الي 35 الحرف",
                        trigger: "blur"
                    }
                ],
                Email: [
                    {
                        required: true,
                        message: "الرجاء إدخال البريد الإلكتروني",
                        trigger: "blur"
                    },
                    {
                        min: 5,
                        max: 40,
                        message:
                            "يجب ان يكون طول البريد الإلكتروني من 5 الي 40 الحرف",
                        trigger: "blur"
                    },
                    {
                        required: true,
                        pattern: /\S+@\S+\.\S+/,
                        message: "الرجاء إدخال البريد بطريقة الصحيحه",
                        trigger: "blur"
                    }
                ],
                Password: [
                    {
                        required: true,
                        message: "الرجاء إدخال الرقم السري",
                        trigger: "blur"
                    },
                    {
                        min: 6,
                        max: 20,
                        message: "يجب ان يكون طول رقم من 20 الي 6 الحرف",
                        trigger: "blur"
                    }
                ],

                Gender: [
                    {
                        required: true,
                        message: "الرجاء إختيار الجنس",
                        trigger: "change"
                    }
                ],
                SchoolId: [
                    {
                        required: true,
                        message: "الرجاء إختيار اسم المدرسة ",
                        trigger: "change"
                    }
                ],
                AcadimecYearId: [
                    {
                        required: true,
                        message: "الرجاء إختيار السنة الدراسية ",
                        trigger: "change"
                    }
                ]
            }
        };
    },
    methods: {
        uploadImage(e) {
            var files = e.target.files;
            if (files.length <= 0) {
                return;
            }

            if (
                files[0].type !== "image/jpeg" &&
                files[0].type !== "image/png"
            ) {
                this.$message({
                    type: "error",
                    message: "عفوا يجب انت تكون الصورة من نوع JPG ,PNG"
                });
                this.photo = null;
                return;
            }

            var $this = this;

            var reader = new FileReader();
            reader.onload = function() {
                $this.imageData = reader.result;
                $this.ruleForm.photo = reader.result;
            };
            reader.onerror = function(error) {
                $this.photo = null;
            };
            reader.readAsDataURL(files[0]);
        },
        submitForm(formName) {
            this.$refs[formName].validate(valid => {
                if (valid) {
                    if (this.ruleForm.Password !== this.ConfirmPassword) {
                        this.$message({
                            type: "error",
                            message: "الرجاء التحقق من تأكيد الرقم السري"
                        });
                        return;
                    }
                    this.$blockUI.Start();
                    this.photo = this.ruleForm.Image;
                    //this.ruleForm.BirthDate = moment(this.ruleForm.BirthDate).format('YYYY-MM-DD HH:mm:ss');
                    this.$http
                        .SignupStudent(this.ruleForm)
                        .then(response => {
                            this.$blockUI.Stop();
                            // this.$alert('<h4>' + 'تم تسجيل بياناتك بنجاح وارسال بريد التحقق بنجاح الرجاء فتح بريدك الإلكتروني ' + '</h4>', '', this.success);

                            swal({
                                title: "Success",
                                text:
                                    "تم تسجيل بياناتك بنجاح وارسال بريد التحقق بنجاح الرجاء فتح بريدك الإلكتروني ",
                                icon: "success",
                                button: "Ok"
                            }).then(value => {
                                window.location.href = "/";
                            });
                            this.$refs[formName].resetFields();
                        })
                        .catch(error => {
                            this.$blockUI.Stop();
                            console.log(error.response.status);
                            if (error.response.status === 400) {
                                this.$alert(
                                    "<h4>" + error.response.data + "</h4>",
                                    "",
                                    this.warning
                                );
                            }
                            if (error.response.status === 404) {
                                this.$alert(
                                    "<h4>" + error.response.data + "</h4>",
                                    "",
                                    this.error
                                );
                            } else {
                                this.$alert(
                                    "<h4>" + error.response.data + "</h4>",
                                    "",
                                    this.error
                                );
                            }
                        });
                } else {
                    console.log("error submit!!");
                    return false;
                }
            });
        },

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },

        GetStudentProfile() {
            this.$blockUI.Start();
            this.$http
                .GetStudentProfile()
                .then(response => {
                    this.$blockUI.Stop();
                    this.ruleForm.FirstName = response.data.student[0].firstName;
                    console.log(response.data.student[0]);
                    this.ruleForm.FirstName = response.data.student[0].acadimacYears;
                    this.ruleForm.FirstName = response.data.student[0].nID;
                    this.ruleForm.FirstName = response.data.student[0].fatherName;
                    this.ruleForm.FirstName = response.data.student[0].grandFatherName;
                    this.ruleForm.FirstName = response.data.student[0].surName;
                    this.ruleForm.FirstName = response.data.student[0].address;
                    this.ruleForm.FirstName = response.data.student[0].email;
                    this.ruleForm.FirstName = response.data.student[0].image;
                    console.log(response.data.student[0]);
                })
                .catch(err => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        GetAllAcadimacYears() {
            this.$blockUI.Start();
            this.$http
                .GetAllAcadimacYears()
                .then(response => {
                    this.$blockUI.Stop();
                    this.AcadimacYears = response.data.acadimacYears;
                })
                .catch(err => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        }
    }
};
