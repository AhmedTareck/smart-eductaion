 



export default {
name: 'addStudent',   
    components: {
       
    },
    created() {

        this.sex=[
                {
                    id: 1,
                    name: "دكر"
                },
                {
                    id: 2,
                    name: 'انتي'
                }


        ];
        
    },
    
    data() {
        return {
            
            
            //Persnal Info Data

            sex:[],
            PersnalInfoForm: {
                eventId:this.$parent.EventSelectd,
                firstName:'',
                fatherName:'',
                grandFatherName:'',
                matherName:'',
                surName:'',
                
                
                selectedSex:[],
                
                address:'',
                phone:'',
                parnsPhone:'',
            },
            
        };
    },

filters: {
        moment: function (date) {
            if (date === null) {
                return 'فارغ';
            }
            // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            return moment(date).format('MMMM Do YYYY');
        }
},

methods: {

    submitForm(formName) {

        this.$http.AddStudent(this.PersnalInfoForm)
                .then(response => {
                    this.$parent.state = 0;
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.$parent.GetStudent();
                    this.$blockUI.Stop();
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    this.$message({
                        type: 'error',
                        message: err.response.data
                    });
                });

/*

        this.$refs[formName].validate((valid) => {
            if (valid) {
                debugger
                
                //this.resetForm(formName);
                //this.PersnalInfoForm.grandFatherName='';

            } else {
                console.log('error submit!!');
                return false;
            }
        });*/

            
    },

    resetForm(formName) {
        this.$refs[formName].resetFields();
    },

    back()
    {
        this.resetForm('PersnalInfoForm');
        this.$parent.state=0;
    }

      


    }
    
}
