import React from 'react';
import './index.css';
import UserProfile from './pages/UserProfile.tsx';
import FriendsList from './pages/FriendsList.tsx';
import AddPost from './pages/AddPost.tsx';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';


ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <BrowserRouter>
            <Routes>
                <Route path="/UserProfile" element={<UserProfile />} />
                <Route path="/FriendsList" element={<FriendsList />} />
                <Route path="/AddPost" element={<AddPost />} />
            </Routes>
        </BrowserRouter>
    </React.StrictMode>
);

//createRoot(document.getElementById('root')!).render(
//    <StrictMode>
//    <FriendsList />
//  </StrictMode>,
//)
