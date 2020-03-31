

export default {
    name: 'Topics',
    components: {

    },
    created() {
    },
    data() {
        return {
            selectedChapterIndex: null,
            highlightedLectureIndex: null,
            selectedLectureIndex: null,
            savedSelectedChapterIndex: null,
            hover: false,
            contentLink: '#Content',
            chapters: [{
                id: 0,
                title: "الفصل الأول",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                },
                {
                    Id: 2,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الثالثة"
                }]
            }, {
                id: 1,
                title: "الفصل الثاني",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                },
                {
                    Id: 2,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الثالثة"
                },
                {
                    Id: 3,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الرابعة"
                }]
            }, {
                id: 2,
                title: "الفصل الثالث",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                }]
            }, {
                id: 0,
                title: "الفصل الرابع",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                },
                {
                    Id: 2,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الثالثة"
                }]
            }, {
                id: 1,
                title: "الفصل الخامس",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                },
                {
                    Id: 2,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الثالثة"
                },
                {
                    Id: 3,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الرابعة"
                }]
            }, {
                id: 2,
                title: "الفصل السادس",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                }]
            }, {
                id: 0,
                title: "الفصل السابع",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                },
                {
                    Id: 2,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الثالثة"
                }]
            }, {
                id: 1,
                title: "الفصل الثامن",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                },
                {
                    Id: 2,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الثالثة"
                },
                {
                    Id: 3,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الرابعة"
                }]
            }, {
                id: 2,
                title: "الفصل التاسع",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                }]
            }, {
                id: 0,
                title: "الفصل العاشر",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                },
                {
                    Id: 2,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الثالثة"
                }]
            }, {
                id: 1,
                title: "الفصل الحادي عاشر",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                },
                {
                    Id: 2,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الثالثة"
                },
                {
                    Id: 3,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الرابعة"
                }]
            }, {
                id: 2,
                title: "الفصل الثاني عشر",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                }]
            }]
        };
    },
    methods: {
        setselectedChapterIndex(index) {
            if (this.selectedChapterIndex !== index) {
                this.selectedChapterIndex = index;
            } else if (this.selectedChapterIndex === index) {

                this.selectedChapterIndex = null;
            }

        }, sethighlightedLectureIndex(index) {

            this.highlightedLectureIndex = index;


        },
        setSelectedLectureIndex(index) {
            this.selectedLectureIndex = index;
            this.savedSelectedChapterIndex = this.selectedChapterIndex;
        },
        displayLecture(index, lectureIndex) {
            this.$emit('lecture', this.chapters[index].lectures[lectureIndex]);
        }
    }
}
