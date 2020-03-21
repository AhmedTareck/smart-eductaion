
export default {
name: 'AddExaming',    
created() {
    this.AddLecture=false;
    this.UpdateAction=0;
},



props: ['QuestionList'],

    data() {
        return {

            ruleForm: {
                Name:'',
                Number:'',
                FullMarck:'',
                Lenght: '',
                QuestionsObj: [],
            },

            Question: {
                Number:'',
                Points:'',
                Question:'',
                Answer:'',
                A1:'',
                A2:'',
                A3:'',
                A4:'',
            },


            
          
         
        };
    },
    methods: {

        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.addQuestion(formName);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },
        
        addQuestion(formName) {
            var question = {
                Number: this.Question.Number,
                Points: this.Question.Points,
                Question: this.Question.Question,
                Answer: this.Question.Answer,
                A1: this.Question.A1,
                A2: this.Question.A2,
                A3: this.Question.A3,
                A4: this.Question.A4,
            };

            this.ruleForm.QuestionsObj.push(question);
            this.resetForm(formName);
        },

        removeQuestion(index) {
            this.ruleForm.QuestionsObj.splice(index, 1);
        },

        submitExamForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.addExam(formName);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        },


        addExam(formName) {
            this.$blockUI.Start();
            this.$http.addExam(this.ruleForm)
                .then(response => {
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.resetForm(formName);
                    this.ruleForm.QuestionsObj=[],
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



    },

}
