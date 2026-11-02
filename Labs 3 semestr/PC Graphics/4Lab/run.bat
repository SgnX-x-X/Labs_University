@echo off
chcp 65001 >nul
echo Запуск приложения обработки изображений...
py main.py
if errorlevel 1 (
    echo.
    echo Ошибка при запуске. Проверьте Python.
    pause
)
