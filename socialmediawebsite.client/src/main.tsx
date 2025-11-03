import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import Profile from './pages/UserProfile.tsx'
import FriendsList from './pages/FriendsList.tsx'

createRoot(document.getElementById('root')!).render(
    <StrictMode>
    <FriendsList />
  </StrictMode>,
)
