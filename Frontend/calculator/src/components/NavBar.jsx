import React, { useState } from 'react';
import { NavLink } from 'react-router-dom';

export default function NavBar() {
    // Начальное состояние для активной ссылки
    const [activeLink, setActiveLink] = useState('/basic');

    // Функция для обработки клика по ссылке
    const handleLinkClick = (link) => {
        setActiveLink(link);
    };

    return (
        <nav className="m-auto content-center w-96 bg-slate-200 rounded-3xl">
            <ul className="flex justify-between p-4">
                <li>
                    <NavLink
                        to="/basic"
                        className={`px-5 py-2 rounded-3xl ${activeLink === '/basic' ? 'bg-slate-400' : ''}`}
                        onClick={() => handleLinkClick('/basic')}
                    >
                        Базовые операции
                    </NavLink>
                </li>
                <li>
                    <NavLink
                        to="/expression"
                        className={`px-5 py-2 rounded-3xl ${activeLink === '/expression' ? 'bg-slate-400' : ''}`}
                        onClick={() => handleLinkClick('/expression')}
                    >
                        Выражение
                    </NavLink>
                </li>
            </ul>
        </nav>
    );
}
