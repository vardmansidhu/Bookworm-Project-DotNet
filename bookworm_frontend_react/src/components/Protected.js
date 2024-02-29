import React from 'react'
import { useNavigate } from 'react-router-dom'

export default function Protected({ isSignedIn, children }) {
    const navigate = useNavigate();

    if (!isSignedIn)
        return navigate('/');
    return children
}
