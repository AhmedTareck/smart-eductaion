

export default {
    name: 'SignUp',
    components: {
      
    },
    created() {        
    },
    data() {
        return {
            ConfirmPassword:'',
            ruleForm: {
                FirstName: '',
                FatherName: '',
                GrandFatherName: '',
                SurName: '',
                MatherName: '',
                BirthDate: '',
                NID: '',
                Address: '',
                Phone: '',
                Gender: '',
                SchoolId: '',
                AcadimecYearId: '',
                Image: '',
                LoginName: '',
                Email: '',
                Password: ''
           
                //name: '',
                //region: '',
                //date1: '',
                //date2: '',
                //delivery: false,
                //type: [],
                //resource: '',
                //desc: ''
            },
            rules: {
                FirstName: [
                    { required: true, message: 'الرجاء إدخال الاسم', trigger: 'blur' },
                    { min: 2, max: 13, message: 'يجب ان يكون طول الإسم من 2 الي 13 الحرف', trigger: 'blur' }
                ],
                FatherName: [
                    { required: true, message: 'الرجاء إدخال إسم الأب', trigger: 'blur' },
                    { min: 2, max: 13, message: 'يجب ان يكون طول الإسم من 2 الي 13 الحرف', trigger: 'blur' }
                ],
                GrandFatherName: [
                    { required: true, message: 'الرجاء إدخال إسم الجد', trigger: 'blur' },
                    { min: 2, max: 13, message: 'يجب ان يكون طول الإسم من 2 الي 13 الحرف', trigger: 'blur' }
                ],
                SurName: [
                    { required: true, message: 'الرجاء إدخال اللقب', trigger: 'blur' },
                    { min: 2, max: 13, message: 'يجب ان يكون طول اللقب من 2 الي 13 الحرف', trigger: 'blur' }
                ],
                //region: [
                //    { required: true, message: 'Please select Activity zone', trigger: 'change' }
                //],
                //date1: [
                //    { type: 'date', required: true, message: 'Please pick a date', trigger: 'change' }
                //],
                //date2: [
                //    { type: 'date', required: true, message: 'Please pick a time', trigger: 'change' }
                //],
                //type: [
                //    { type: 'array', required: true, message: 'Please select at least one activity type', trigger: 'change' }
                //],
                //resource: [
                //    { required: true, message: 'Please select activity resource', trigger: 'change' }
                //],
                //desc: [
                //    { required: true, message: 'Please input activity form', trigger: 'blur' }
                //]
            }
        };
    },
    methods: {
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    alert('submit!');
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        },
        resetForm(formName) {
            this.$refs[formName].resetFields();
        }

    }    
}
