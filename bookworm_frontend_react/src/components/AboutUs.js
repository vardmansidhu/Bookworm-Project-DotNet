import React from 'react';
import TeamMember from './TeamMember';
import '../css/AboutUs.css';

const AboutUs = () => {

    const mentors = [
        {
            name: 'Jayant Ponkshe',
            role: 'Guide',
            git: 'Role : Client',
            linkedin: '',
            imageUrl: './images/JayantPonkshe.jpg',
        },
        {
            name: 'Nitin Vijaykar',
            role: 'Guide',
            git: 'Role : Guide',
            linkedin: '',
            imageUrl: './images/NitinVijaykar.jpg',
        },
        {
            name: 'Ketki Acharya',
            role: 'Guide',
            git: 'Role : Guide',
            linkedin: '',
            imageUrl: './images/KetkiAcharya.jpg',
        },
    ];

    const teamMembers = [
        {
            name: 'Kunal Dhanawade',
            role: 'Team-Lead',
            git: <a target="_blank" href='https://github.com/kunaldhanawade'>GitHub </a>,
            linkedin: <a target="_blank" href='https://www.linkedin.com/in/dhanawade-kunal/'>LinkedIn </a>,
            imageUrl: './images/KunalDhanawade.jpg',
        },

        {
            name: 'Divyanshu Yadav',
            role: 'Team-Member',
            git: <a target="_blank" href='https://github.com/DIVYANSHUYYADAV'>GitHub </a>,
            linkedin: <a target="_blank" href='https://www.linkedin.com/in/divyanshu-yadav-189a3a1b2/'>LinkedIn </a>,
            imageUrl: './images/DivyanshuYadav.jpg',
        },

        {
            name: 'Mayuri Kamble',
            role: 'Team-Member',
            git: <a target="_blank" href='https://github.com/MayuriKamble04'>GitHub </a>,
            linkedin: <a target="_blank" href='https://www.linkedin.com/in/mayurikamble/'>LinkedIn </a>,
            imageUrl: './images/MayuriKamble.jpg',
        },

        {
            name: 'Obaidur Khan',
            role: 'Team-Member',
            git: <a target="_blank" href='#'>GitHub </a>,
            linkedin: <a target="_blank" href='https://www.linkedin.com/in/obaidur-rahman-khan-5b549729b/'>LinkedIn </a>,
            imageUrl: './images/ObaidurKhan.jpg',
        },

        {
            name: 'Shubham Korgaonkar',
            role: 'Team-Member',
            git: <a target="_blank" href='https://github.com/ShubhamKorgaonkar'>GitHub </a>,
            linkedin: <a target="_blank" href='https://www.linkedin.com/in/shubham-k-5b3533265/'>LinkedIn </a>,
            imageUrl: './images/ShubhamKorgaonkar.jpg',
        },

        {
            name: 'Swapnil Nikumbh',
            role: 'Team-Member',
            git: <a target="_blank" href='https://github.com/nikumbhswapnil'>GitHub </a>,
            linkedin: <a target="_blank" href='https://www.linkedin.com/in/swapnil-nikumbh-63445418b/'>LinkedIn </a>,
            imageUrl: './images/SwapnilNikumbh.jpg',
        },

        {
            name: 'Vardman Sidhu',
            role: 'Team-Member',
            git: <a target="_blank" href='https://github.com/vardmansidhu'>GitHub </a>,
            linkedin: <a target="_blank" href='https://www.linkedin.com/in/vardhman-sidhu-bb7853192/'>LinkedIn </a>,
            imageUrl: './images/VardmanSidhu.jpg',
        },

        {
            name: 'Vedant Dhadange',
            role: 'Team-Member',
            git: <a target="_blank" href='https://github.com/vedantsd03'>GitHub </a>,
            linkedin: <a target="_blank" href='https://www.linkedin.com/in/vedant-dhadange/'>LinkedIn </a>,
            imageUrl: './images/VedantDhadange.jpg',
        },

        {
            name: 'Yash Hajare',
            role: 'Team-Member',
            git: <a target="_blank" href='https://github.com/YashHajare18'>GitHub </a>,
            linkedin: <a target="_blank" href='https://www.linkedin.com/in/yash-hajare-a30b79240/'>LinkedIn </a>,
            imageUrl: './images/YashHajare.jpg',
        },
    ];

    return (
        <div id="about-sec">
            <div className='container'>
                <header>
                    <h1>About Bookworm</h1>
                </header>
                <br />
                <section>
                    <h2>Our Mission</h2>
                    <p>
                        At Bookworm, our mission is to make the joy of reading accessible to everyone. We strive to create a digital platform that connects readers with a diverse range of books, fostering a community of lifelong learners and book enthusiasts.
                    </p>
                </section>
                <section>
                    <h2>Our Vision</h2>
                    <p>
                        We envision a future where people from all walks of life can easily discover, borrow, and enjoy a wide array of literary works. Through innovation and a passion for literature, we aim to revolutionize the way people access and experience books.
                    </p>
                </section>

                <section>
                    <h2>Our Values</h2>
                    <ul>
                        <li><strong>Accessibility:</strong> We are committed to making literature available to all, breaking down barriers to reading and learning.</li>
                        <li><strong>Diversity:</strong> We celebrate the richness of diverse voices and perspectives, curating a collection that reflects the breadth of human experience.</li>
                        <li><strong>Quality:</strong> We prioritize delivering high-quality content and user experiences to our community.</li>
                        <li><strong>Community:</strong> Bookworm is more than a platform; it's a community of readers united by a shared love for books.</li>
                    </ul>
                </section>
            </div>
            <div className="about-us">
                <br />
                <main>
                    {/* Existing content */}

                    <h2>Our Mentors</h2>
                    <div className="team-members">
                        {mentors.map((member, index) => (
                            <TeamMember key={index} {...member} />
                        ))}
                    </div>


                    <h2>Our Team:</h2>
                    <div className="team-members">
                        {teamMembers.map((member, index) => (
                            <TeamMember key={index} {...member} />
                        ))}
                    </div>

                    {/* More existing content */}
                </main>
            </div>
        </div>
    );
};

export default AboutUs;