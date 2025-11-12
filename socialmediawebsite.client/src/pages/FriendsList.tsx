import { useEffect, useState } from 'react';
import type { CSSProperties } from 'react';
import { apiFetch } from '../services/api';
import { useLocation } from 'react-router-dom';

interface Friend {
    id: number;
    username: string;
    fullname: string;
}

function FriendsList() {
    const [friendsList, setFriendsList] = useState<Friend[]>([]);
    const [peopleMayKnowList, setPeopleMayKnowList] = useState<Friend[]>([]);

    const location = useLocation();
    const searchParams = new URLSearchParams(location.search);
    const myUserId: number = Number(searchParams.get('userId')) || 1;

    async function addFriend(newFriend: Friend) {

        try {
            await apiFetch('api/Friends/addfriend', {
                method: "POST",
                body: {
                    userId: myUserId,
                    friendId: newFriend.id
                }
            });

            setFriendsList(prev => [...prev, newFriend]);
            alert("Added successfully");
        } catch (error) {
            console.error("Failed to add friend: ", error)
            alert("Failed to add friend.");
        }

        // Remove from people you may know list
        setPeopleMayKnowList(prev => prev.filter(p => p.id !== newFriend.id));
    }

    async function removeFriend(friend: Friend) {

        try {
            await apiFetch('api/Friends/removefriend', {
                method: "POST",
                body: {
                    userId: myUserId,
                    friendId: friend.id
                }
            });

            alert('remove success');
        } catch (error) {
            console.error("Failed to remove friend: " + error);
            alert("Failed to remove friend.");
        }

        setPeopleMayKnowList(prev => [...prev, friend]);
        setFriendsList(prev => prev.filter(f => f.id !== friend.id))
    }

    useEffect(() => {
        async function loadFriendsList() {
            try {
                const myFriendsList = await apiFetch<Friend[]>('api/Friends/getfriends?userId=' + myUserId);
                setFriendsList(myFriendsList);
            }
            catch (error) {
                console.error("Failed to load friends list: " + error);
                alert("Failed to load friends list");
            }
        }

        async function loadPeopleMayKnowList() {
            try {
                const myPeopleMayKnowList = await apiFetch<Friend[]>(`api/Friends/getpeoplemayknow?userId=${myUserId}`);
                setPeopleMayKnowList(myPeopleMayKnowList);
            } catch (error) {
                console.error("Failed to load people you may know list: " + error);
                alert("Failed to load prople you may know list");
            }
        }

        loadFriendsList();
        loadPeopleMayKnowList();
    }, []);


    return (
        <>
            <h1>Friends List</h1>
            <ul>
                {friendsList.map((user) => (
                    <li key={user.id}>
                        <img
                            style={{ width: '40px' }}
                            alt={user.username}
                            src={`/profilePics/${user.id}.jpg`}
                            onError={e => {
                                const target = e.currentTarget as HTMLImageElement;
                                target.onerror = null; // Prevent infinite loop if placeholder is missing
                                target.src = '/profilePics/none.jpg';
                            }}
                        />
                        <div>
                            <a href={`/userprofile?userId=${user.id}`}>{user.username}</a>
                        </div>
                        <span style={fullNameSpan}>{user.fullname}</span>
                        <button onClick={() => removeFriend(user)}>Remove</button>
                    </li>
                ))}
            </ul>

            <h1>People You May Know</h1>
            <ul>
                {peopleMayKnowList.map((user) => (
                    <li key={user.id}>
                        <img
                            style={{ width: '40px' }}
                            alt={user.username}
                            src={`/profilePics/${user.id}.jpg`}
                            onError={e => {
                                const target = e.currentTarget as HTMLImageElement;
                                target.onerror = null; // Prevent infinite loop if placeholder is missing
                                target.src = '/profilePics/none.jpg';
                            }}
                        />
                        <div>
                            <a href={`/userprofile?userId=${user.id}`}>{user.username}</a>
                        </div>
                        <span style={fullNameSpan}>{user.fullname}</span>
                        <button onClick={() => addFriend(user)}>Add</button>
                    </li>
                )) }
            </ul>
        </>
        
    );
}

export default FriendsList;

const fullNameSpan: CSSProperties = {
    fontStyle: 'italic'

};