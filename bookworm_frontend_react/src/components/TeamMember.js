import React from 'react';

const TeamMember = ({ name, role,git,linkedin, imageUrl }) => (
  <div className="team-member">
    <img src={imageUrl} alt={name} />
    <h3>{name}</h3>
    <p>{role}</p>
    <p>{git}</p>
    <p>{linkedin}</p>
  </div>
);

export default TeamMember;