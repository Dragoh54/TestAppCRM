import { useState } from 'react'

export default function App() {
  return (
    <div className="min-h-screen flex items-center justify-center bg-slate-100">
            <button
                className="
                    rounded-xl
                    bg-blue-600
                    px-6
                    py-3
                    text-white
                    font-semibold
                    shadow-md
                    transition
                    hover:bg-blue-700
                    hover:scale-105
                "
            >
                Test Button
            </button>
        </div>
  );
}