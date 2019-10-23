import 'quill/dist/quill.core.css';
import 'quill/dist/quill.snow.css';
import 'quill/dist/quill.bubble.css';

import { quillEditor } from 'vue-quill-editor';

export default {

    name: 'NewMessage',

    components: {
        quillEditor
    },
    data() {

        return {


            ruleForm: {
                from: "",
                SentGroup:'',
                selectedusers:[],
                subject: "",
                MessageType: "",
                PermissionModale:[],
                replay: true,
                priority:"",
                dialogImageUrl: '',
                content: "",
                selectedOption: 3,
                files: [],
                PermissionModalePersonal: []

            },
            rules: {
            
                SentGroup: [
                    { required: true, message: 'الرجاء اختيار المرسل الي ', trigger: 'change' }
                ],
                subject: [
                    { required: true, message: 'الرجاء ادخال   عنوان التعميم', trigger: 'blur' }
                ],
                MessageType: [
                    { required: true, message: 'الرجاء إدخال نوع التعميم ', trigger: 'change' }
                   
                ],
                replay: [
                    { required: true, message: 'اختيار قابليه الرد ', trigger: 'blur' }
                ],
                SentType: [
                    { required: true, message: 'اختيار نوع الارسال ', trigger: 'change' }
                ]


            },
            state: 1,
            list: [],
            users: [],
            SentType:[],
            editorOption: {
                //debug: 'info',
                //placeholder: " ",
                //readOnly: true,
                //theme: 'snow',
                //modules: {
                //    toolbar: [
                //        ['bold', 'italic', 'underline'],
                //        ['code-block'],
                //        [{ 'color': [] }, { 'background': [] }],
                //        [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                //        [{ 'direction': 'rtl' }],
                //        [{ 'align': [] }],

                //    ],
                //},
            },
            types: [],
            loading: false,
            dialogVisible: false,
            Prioritytexts: [' عادي ', ' متوسط ', ' مهم '],
            priorityint: null,
            checkAll: false,
            options: ['البريد الإلكتروني', 'رسالة نصية'],
            isIndeterminate: false,
            checkOptions: [],
            selectFiles: [],
            Permissions:[]

        };
    },
  
    created() {
      
        this.GetAllAdTypes();
        this.Permissions = [
            {
                id: 1,
                name: "الإدارات"
            },
            {
                id: 2,
                name: 'إدارة الفروع'
            },
            {
                id: 3,
                name: 'مكاتب اللإصدار'
            },
            {
                id: 4,
                name: 'المكاتب الخدمية'
            }

        ];
        this.SentType = [
            {
                id: 1,
                name: "الكل"
            },
            {
                id: 2,
                name: 'البريد الالكتروني'
            },
            {
                id: 3,
                name: 'رساله قصيره'
            }
           

        ];
    },

    methods: {

        selectUser() {
            if (this.ruleForm.SentGroup == 1) {
                this.GetAllUsers();
                this.ruleForm.PermissionModale = [];
        } else {
                this.ruleForm.PermissionModalePersonal = [];
                this.ruleForm.selectedusers = [];
        }
    },
        SelectUserByType() {
            this.GetAllUsers();
        },
        handleCheckAllChange(val) {
            
            this.checkOptions = val ? this.options : [];
            this.form.selectedOption = val ? 0 : null;
            this.isIndeterminate = false;
            
        },
        handleCheckedOptionChange(value) {
            
            let checkedCount = value.length;
            this.checkAll = checkedCount === this.options.length;
           
            this.isIndeterminate = checkedCount > 0 && checkedCount < this.options.length;
            if (this.checkAll) {
                this.ruleForm.selectedOption = 0;
                return;
            } else if (value[0]=== this.options[0]) {
                this.ruleForm.selectedOption = 1;
            } else if (value[0]=== this.options[1]) {
                this.ruleForm.selectedOption = 2;
            } else {
                this.ruleForm.selectedOption = 3;
            }

        },
        FileChanged(file, fileList) {
          
            var fileSize = (file.size / 1024) | 0;
            if (fileSize > 8000) 
            {
               
                this.$message({
                    type: 'error',
                    dangerouslyUseHTMLString: true,
                    duration: 5000,
                    message: '<strong>' + 'الرجاء تطابق كلمة المرورحجم الملف كبير لايمكن تحميله' + '</strong>'
                });
                return;
            }
            var $this = this;
            var reader = new FileReader();
            reader.readAsDataURL(file.raw);
            reader.onload = function (e) {
                var obj =
                {
                    fileName: file.raw.name,
                    fileBase64: reader.result,
                    type: file.raw.type
                };
                $this.ruleForm.files.push(obj);
                

            }
            console.log($this.ruleForm.files);
        },
        handleRemove(file) {
            var $this = this;
            var reader = new FileReader();
            reader.readAsDataURL(file.raw);
            reader.onload = function (e) {
                $this.ruleForm.files.splice($this.form.files.indexOf(reader.result), 1);
            }
        },
        handlePictureCardPreview(file) {
            this.ruleForm.dialogImageUrl = file.url;
            this.ruleForm.dialogVisible = true;
        },
        GetAllUsers() {
      
                this.$blockUI.Start();
            this.$http.GetAllUsers(this.ruleForm.PermissionModalePersonal)
                    .then(response => {
                       
                        this.$blockUI.Stop();
                        this.users = response.data.users;
                       
                    })
                    .catch((err) => {
                      
                        this.$blockUI.Stop();
                        this.$message({
                            type: 'error',
                            message: err.message.data
                        }); 
                    });
           
        },
        GetAllAdTypes()
        {
            this.loading = true;
            this.$blockUI.Start();
            this.$http.GetAllAdTypes()
                .then(response => {
                  
                    this.$blockUI.Stop();
                    this.types = response.data.adTypes;
             
                })
                .catch((err) => {
                    this.loading = false;
                    this.$blockUI.Stop();
                    this.$message({
                        type: 'error',
                        message: err.message.data
                    }); 
                });
        },
        SendMessage()
        {
 

            //if (this.form.selectedusers.length < 1)
            //{
            //    this.$message({
            //        type: 'error',
            //        message: 'الرجاء اختيار علي الاقل مستقبل واحد'
            //    });
            //    return;
            //}
            //if (!this.form.subject) {
            //    this.$message({
            //        type: 'error',
            //        message: 'الرجاء ادخال العنوان'
            //    });
            //    return;
            //}
            //if (!this.form.type) {
            //    this.$message({
            //        type: 'error',
            //        message: 'الرجاء اختيار نوع التعميم'
            //    });
            //    return;
            //}
            //if (!this.form.content) {
            //    this.$message({
            //        type: 'error',
            //        message: 'الرجاء ادخال محتوي التعميم'
            //    });
            //    return;
            //}
            this.$blockUI.Start();
            this.ruleForm.priority = this.Prioritytexts[this.priorityint - 1];
            this.$http.NewMessage(this.form)
                .then(response => {
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.form = [];
                    this.$router.push('/Inbox');
                    this.$blockUI.Stop();
                })
                .catch((err) => {
                    this.$message({
                        type: 'error',
                        message: err.message.data
                    }); 
                    this.$blockUI.Stop();
                });
        },
           Save(formName) {

           
               this.$blockUI.Start();
               this.ruleForm.priority = this.Prioritytexts[this.priorityint - 1];
            this.$refs[formName].validate((valid) => {
                if (valid) {
                 
                 
                    this.$http.NewMessage(this.ruleForm)
                        .then(response => {
                           
                            this.$message({
                                type: 'success',
                                dangerouslyUseHTMLString: true,
                                duration: 5000,
                                message: '<strong>' + response.data + '</strong>'
                            });

                            this.form = [];
                            this.$router.push('/Inbox');
                            this.$blockUI.Stop();
                        })
                        .catch((err) => {
                            this.$blockUI.Stop();
                            this.$message({
                                type: 'error',
                                dangerouslyUseHTMLString: true,
                                duration: 5000,
                                message: '<strong>' + err.response.data + '</strong>'
                            });
                        });
                } else {
                    this.$blockUI.Stop();
                    console.log('error submit!!');
                    return false;
                }
            });


        }
    }
}
