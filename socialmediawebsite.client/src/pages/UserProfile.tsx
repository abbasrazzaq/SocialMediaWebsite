import { useEffect, useState } from 'react';
import type { CSSProperties } from 'react';
import { useLocation } from 'react-router-dom';
import { apiFetch } from '../services/api';

interface UserProfile {
    id: number;
    username: string;
    fullname: string;
    age: number;
    location: string;
    workplace: string;
    hometown: string;
    studiedAt: string;
}

function Profile() {
    const [userProfile, setUserProfile] = useState<UserProfile | null>(null);

    const location = useLocation();
    const searchParams = new URLSearchParams(location.search);
    const myUserId = Number(searchParams.get('userId')) || 1;

    useEffect(() => {
        async function loadUserProfile() {
            const response = await apiFetch<UserProfile>('api/userprofile/getprofileinfo?userId=' + myUserId);
            setUserProfile(response);
        }

        loadUserProfile();

    }, []);

    const noProfilePicImg: string = '/profilePics/none.jpg';

    const contents = userProfile === null
        ? <p>Loading...</p>
        : <div>
            <img
                style={{ width: '80px' }}
                alt={noProfilePicImg}
                src={`/profilePics/${userProfile.id}.jpg`}
                onError={e => {
                    const target = e.currentTarget as HTMLImageElement;
                    target.onerror = null; // Prevent infinite loop if placeholder is missing
                    target.src = '/profilePics/none.jpg'
                }}
            />
            <div style={profileDiv}>
                <h1>User Profile</h1>
                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Username</span>
                    <span style={profileDivSpan}>{userProfile.username}</span>
                </label>
            </div>

            <div style={profileDiv}>
                <h2>Bio</h2>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Name:</span>
                    <span style={profileDivSpan}>{userProfile.fullname}</span>
                </label>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Age:</span>
                    <span style={profileDivSpan}>{userProfile.age}</span>
                </label>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Lives:</span>
                    <span style={profileDivSpan}>{userProfile.location}</span>
                </label>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Workplace:</span>
                    <span style={profileDivSpan}>{userProfile.workplace}</span>
                </label>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>From:</span>
                    <span style={profileDivSpan}>{userProfile.hometown}</span>
                </label>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Studied at:</span>
                    <span style={profileDivSpan}>{userProfile.studiedAt}</span>
                </label>
            </div>
        </div>;

    return (
        <div>
            {contents}
        </div>   
    );
}

export default Profile;


const profileDiv: CSSProperties = {
    color: 'black'
};

const profileDivLabel: CSSProperties = {
    display: 'flex'
};

const profileDivSpan: CSSProperties = {
    display: 'flex',
    maxWidth: '250px',
    padding: '24px',
};