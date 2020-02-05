 



export default {
    name: 'AddYears',   
    components: {
       
    },
    created() {

        this.GetYears();

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

            Years: [],
            YearSelected: '',

            Events: [],
            EventSelectd: '',

            sex:[],
            PersnalInfoForm: {
                EventId:'',
                firstName:'',
                fatherName:'',
                grandFatherName:'',
                matherName:'',
                surName:'', 
                
                
                selectedSex:[],
                
                Adrress:'',
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

        GetYears() {
            this.$blockUI.Start();
            this.$http.GetYears()
                .then(response => {

                    this.$blockUI.Stop();
                    this.Years = response.data.years;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getEvents() {
            this.EventSelectd = '';
            this.$blockUI.Start();
            this.$http.GetEvents(this.YearSelected)

                .then(response => {

                    this.$blockUI.Stop();
                    this.Events = response.data.events;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.addStudent(formName);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },

        addStudent(formName) {
            debugger
            this.$http.AddStudent(this.PersnalInfoForm)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.resetForm(formName);
                        this.YearSelected = '';
                        this.$blockUI.Stop();
                    })
                    .catch((err) => {
                        this.$blockUI.Stop();
                        this.$message({
                            type: 'error',
                            message: err.response.data
                        });
                    });
            
        },

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },


    }
    
}
