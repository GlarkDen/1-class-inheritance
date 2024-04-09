namespace Lab_10
{
    /// <summary>
    /// Генерация полей объекта
    /// </summary>
    interface IInit : IShow
    {
        /// <summary>
        /// Генерация полей объекта
        /// </summary>
        void Init();
    }

    /// <summary>
    /// Вывод информации об объекте
    /// </summary>
    interface IShow
    {
        /// <summary>
        /// Вывод информации об объекте
        /// </summary>
        void ShowInformation();
    }
}
