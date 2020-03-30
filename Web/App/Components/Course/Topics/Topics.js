

export default {
    name: 'Topics',
    components: {

    },
    created() {
    },
    data() {
        return {
            selectedIndex: null,
            lectures: [{
                id: 0,
                url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                title: "hello world"
            }, {
                id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
            }, {
                id: 2,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                }, {
                    id: 3,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "hello world"
                }, {
                    id: 4,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
                }, {
                    id: 5,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                }, {
                    id: 6,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "hello world"
                }, {
                    id: 7,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
                }, {
                    id: 8,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                },
                {
                    id: 9,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "hello world"
                }, {
                    id: 10,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
                }, {
                    id: 11,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                }, {
                    id: 12,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "hello world"
                }, {
                    id: 13,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
                }, {
                    id: 14,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                }, {
                    id: 15,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "hello world"
                }, {
                    id: 16,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
                }, {
                    id: 17,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                },]
        }
    },
    methods: {
        setSelectedIndex(index) {
            this.selectedIndex = index;
        },
        displayLecture(index) {
            this.$emit('lecture', this.lectures[index]);
        }
    }
}
