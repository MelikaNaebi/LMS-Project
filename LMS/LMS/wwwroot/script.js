document.getElementById("loginForm").addEventListener("submit", async function (event) {
    event.preventDefault();

    let email = document.getElementById("email").value.trim();
    let password = document.getElementById("password").value.trim();
    let errorMessage = document.getElementById("errorMessage");

    // بررسی پر بودن فیلدها
    if (email === "" || password === "") {
        errorMessage.textContent = "لطفاً همه فیلدها را پر کنید.";
        errorMessage.classList.remove("hidden");
        return;
    }

    try {
        // ارسال درخواست ورود به سرور
        let response = await fetch("https://localhost:7188/api/auth/login", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ email, password }),
        });

        let data = await response.json();

        // بررسی پاسخ سرور
        if (!response.ok) {
            errorMessage.textContent = data.message;
            errorMessage.classList.remove("hidden");
        } else {
            // ذخیره توکن در localStorage
            const token = data.token;  // فرض می‌کنیم که توکن در response موجود است
            localStorage.setItem("token", token);  // ذخیره توکن

            // پنهان کردن پیام خطا و نمایش پیام موفقیت
            errorMessage.classList.add("hidden");
            alert("ورود موفقیت‌آمیز بود!");

            // هدایت کاربر به صفحه داشبورد
            window.location.href = "student.html";
        }
    } catch (error) {
        console.error("خطا در ارتباط با سرور:", error);
        errorMessage.textContent = "مشکلی پیش آمده است، لطفاً دوباره امتحان کنید.";
        errorMessage.classList.remove("hidden");
    }
});


