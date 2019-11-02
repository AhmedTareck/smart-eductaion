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
             
            },
            types: [],
            loading: false,
            dialogVisible: false,
            Prioritytexts: [' عادي ', ' متوسط ', ' مهم '],
            priorityint: null,
            checkAll: false,
           
            isIndeterminate: false,
            checkOptions: [],
            selectFiles: [],
            Permissions:[]

        };
    },
  
    created() {
      
        this.GetAllMessageTypes();
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
  
        FileChanged(file, fileList) {
          
            var fileSize = (file.size / 1024) | 0;
           
            if (file.raw.type !== 'image/jpeg' && file.raw.type !== 'image/png' && file.raw.type !== 'application/pdf' && file.raw.type !== 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' && file.raw.type !== 'application/vnd.openxmlformats-officedocument.wordprocessingml.document') {
                this.$message({
                    type: 'error',
                    dangerouslyUseHTMLString: true,
                    duration: 5000,
                    message: 'عفوا يجب انت تكون الملف من نوع JPG ,PNG,pdf,docx,xlsx'
                });
              
                return;
            }
            if (fileSize > 8000) 
            {
               
                this.$message({
                    type: 'error',
                    dangerouslyUseHTMLString: true,
                    duration: 5000,
                    message: '<strong>' + 'حجم الملف كبير لايمكن تحميله' + '</strong>'
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
            if (file.raw.type !== 'image/jpeg' && file.raw.type !== 'image/png' && file.raw.type !== 'application/pdf' && file.raw.type !== 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' && file.raw.type !== 'application/vnd.openxmlformats-officedocument.wordprocessingml.document') {
                this.$message({
                    type: 'error',
                    dangerouslyUseHTMLString: true,
                    duration: 5000,
                    message: 'عفوا يجب انت تكون الملف من نوع JPG ,PNG,pdf,docx,xlsx'
                });

                return;
            }
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
                            dangerouslyUseHTMLString: true,
                            duration: 5000,
                            message: '<strong>' + err.response.data + '</strong>'
                        });
                    });
           
        },
        GetAllMessageTypes()
        {
        
            this.$blockUI.Start();
            this.$http.GetAllMessageTypes()
                .then(response => {
                  
                    this.$blockUI.Stop();
                    this.types = response.data.messageTypes;
             
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
