import { useEffect, useState } from 'react';
import type { CSSProperties } from 'react';

interface Friend {
    id: number;
    username: string;
    fullname: string;
}

function FriendsList() {
    const [friendsList, setFriendsList] = useState<Friend[]>([]);
    const [peopleMayKnowList, setPeopleMayKnowList] = useState<Friend[]>([]);

    async function addFriend(userId: number, newFriend: Friend) {
        const response = await fetch('api/Friends/addfriend', {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                userId: userId,
                friendId: newFriend.id
            })
        });

        if (response.ok) {
            // Add to friend list
            setFriendsList(prev => [...prev, newFriend]);

            alert("Added successfully");
        }
        else {
            alert("Failed to add.");
        }

        // Remove from people you may know list
        setPeopleMayKnowList(prev => prev.filter(p => p.id !== newFriend.id));
    }

    async function removeFriend(userId: number, friend: Friend) {
        const response = await fetch('api/Friends/removefriend', {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                userId: userId,
                friendId: friend.id
            })
        });

        if (response.ok) {
            alert('remove success');
        }
        else {
            alert('remove failed');
        }

        setPeopleMayKnowList(prev => [...prev, friend]);
        setFriendsList(prev => prev.filter(f => f.id !== friend.id))
    }

    useEffect(() => {
        async function loadFriendsList() {
            const response = await fetch('api/Friends/getfriends', {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                },
            });

            if (response.ok) {
                const data = await response.json();
                setFriendsList(data);
            }
        }

        async function loadPeopleMayKnowList(userId: number) {
            const response = await fetch(`api/Friends/getpeoplemayknow?userId=${userId}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                },
            });

            if (response.ok) {
                const data = await response.json();
                setPeopleMayKnowList(data);
            }
        }

        loadFriendsList();
        loadPeopleMayKnowList(1);
    }, []);

    const noProfilePicImg: string = '/profilePics/none.jpg';

    return (
        <>
            <h1>Friends List</h1>
            <ul>
                {friendsList.map((item) => (
                    <li key={item.id}>
                        <img
                            style={{ width: '40px' }}
                            alt={item.username}
                            src={`/profilePics/${item.id}.jpg`}
                            onError={e => {
                                const target = e.currentTarget as HTMLImageElement;
                                target.onerror = null; // Prevent infinite loop if placeholder is missing
                                target.src = '/profilePics/none.jpg';
                            }}
                        />
                        <div>
                            {item.username}
                        </div>
                        <span style={fullNameSpan}>{item.fullname}</span>
                        <button onClick={() => removeFriend(1, item)}>Remove</button>
                    </li>
                ))}
            </ul>

            <h1>People You May Know</h1>
            <ul>
                {peopleMayKnowList.map((item) => (
                    <li key={item.id}>
                        <img
                            style={{ width: '40px' }}
                            alt={item.username}
                            src={`/profilePics/${item.id}.jpg`}
                            onError={e => {
                                const target = e.currentTarget as HTMLImageElement;
                                target.onerror = null; // Prevent infinite loop if placeholder is missing
                                target.src = '/profilePics/none.jpg';
                            }}
                        />
                        <div>
                            {item.username}
                        </div>
                        <span style={fullNameSpan}>{item.fullname}</span>
                        <button onClick={() => addFriend(1, item)}>Add</button>
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