// Import Firebase libraries (make sure the version matches your Firebase setup)
importScripts('https://www.gstatic.com/firebasejs/8.10.0/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/8.10.0/firebase-messaging.js');

// Initialize Firebase
firebase.initializeApp({
    apiKey: "AIzaSyDBWpn0l-5oTAHsApVJBW9xp0pZHJSlnm4",
    authDomain: "gws-core-399b1.firebaseapp.com",
    projectId: "gws-core-399b1",
    storageBucket: "gws-core-399b1.firebasestorage.app",
    messagingSenderId: "260487603676",
    appId: "1:260487603676:web:4c9f8448b9dffc0a779b19",
    measurementId: "G-95PY49RZ3C",
    vapidKey: 'BM8YcnTa79rqgbJjAj_t5vl1ONAJZ1bxNXjN45hrLXgJsfMQSEoVto2_YLrJapz- zlnzzKozqCYZ1HW_ei1Ow8M',
});
//measurementId: "G-95PY49RZ3C"
// Initialize Firebase Messaging
const messaging = firebase.messaging();

// Handle background notifications
messaging.onBackgroundMessage(function (payload) {
    console.log('Received background message ', payload);

    const notificationTitle = payload.notification.title;
    const notificationOptions = {
        body: payload.notification.body,
        icon: payload.notification.icon || '/default-icon.png', // Optional fallback
        badge: payload.notification.badge || '/default-badge.png', // Optional fallback
    };

    // Show the notification
    self.registration.showNotification(notificationTitle, notificationOptions);
});
