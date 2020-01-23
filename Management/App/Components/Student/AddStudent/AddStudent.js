 



export default {
name: 'addStudent',   
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
                eventId:'',
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

            this.PersnalInfoForm.eventId = this.EventSelectd;


        this.$http.AddStudent(this.PersnalInfoForm)
                .then(response => {
                    this.$parent.state = 0;
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.PersnalInfoForm.phone= '',
                    this.PersnalInfoForm.parnsPhone= '',
                    this.resetForm(formName);
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
