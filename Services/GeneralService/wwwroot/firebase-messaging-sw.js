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
});
//measurementId: "G-95PY49RZ3C"
// Initialize Firebase Messaging
const messaging = firebase.messaging();

// Handle background notifications (when the app is in the background)
messaging.setBackgroundMessageHandler(function(payload) {
  console.log('Received background message ', payload);
  // Customize notification options
  const notificationTitle = 'New Notification';
  const notificationOptions = {
    body: payload.data.status,
    icon: 'firebase-logo.png'
  };

  return self.registration.showNotification(notificationTitle, notificationOptions);
});
