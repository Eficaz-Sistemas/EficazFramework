// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.efcoreJsFunctions = {

    //just a sample function that return a message
    showPrompt: function (message) {
        return prompt(message, 'Type anything here');
    },

    acceptCookieMessage: function (cookieString) {
        document.cookie = cookieString;
    },

    addclass: function (query, className) {
        const found = document.querySelectorAll(query);
        found.forEach(entry => {
            entry.classList.add(className);
        });
    },

    changeUrl: function (url) {
        history.pushState(null, '', url);   
    },


    clickElementByID: function (input) {
        var element = document.getElementById(input);
        element.click();
    },

    clickElement: function (element) {
        element.click();
    },


    focusElement: function (element) {
        element.focus();
    },

    focusElementByID: function (elementID) {
        document.getElementById(elementID).focus();
    },

    focusChildElementByID: function (parentID) {
        var element = document.getElementById(parentID);
        element.firstElementChild.focus();
    },

    focusChildOf: function (parentID, expectedelement) {
        var element = document.getElementById(parentID);
        var target = element.querySelector(expectedelement)
        target.focus();
    },


    findElement: function(selector) {
        return document.querySelectorAll(selector);
    },


    print: function() {
        window.print();
        return false;
    },


    removeclass: function (query, className) {
        const found = document.querySelectorAll(query);
        found.forEach(entry => {
            entry.classList.remove(className);
        });
    },


    scrollToBottom: function(element) {
        element.scrollIntoView({ behavior: 'smooth', block: 'end' });
    },

    scrollToBottomByID: function (elementID) {
        document.getElementById(elementID).scrollIntoView({ behavior: 'smooth', block: 'end' });
    },

    scrollToBottomBySelector: function (selector) {
        var element = this.findElement(selector);
        this.scrollToBottom(element[element.length - 1]);
    },



    startObserve: function (query, intersectingClassName, permanent, func) {
        const found = document.querySelectorAll(query);
        const config = {
            root: null, // use the document's viewport as the container
            rootMargin: '0px', // % or px - offsets added to each side of the intersection 
            threshold: 0.3 // percentage of the target element which is visible
        }

        let observer = new IntersectionObserver(function (entries) {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add(intersectingClassName);
                    if (func !== null) {
                        this[func]();
                    }
                } else {
                    if (!permanent) {
                        entry.target.classList.remove(intersectingClassName);	
                        observer.unobserve(entry);
                    }
                }
            });
        }, config);

        found.forEach(item => observer.observe(item));
    },

    stopObserve: function (query, observerInstance) {
        const found = document.querySelectorAll(query);
        found.forEach(item => observerInstance.unobserve(item));
    }


};


//http://jsfiddle.net/28cuveb1/1/