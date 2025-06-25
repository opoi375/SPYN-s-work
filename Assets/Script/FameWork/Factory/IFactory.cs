namespace Script.FameWork.Factory
{
    /// <summary>
    /// 工厂接口
    /// </summary>
    /// <typeparam name="T">生产产品的类型</typeparam>
    /// <typeparam name="TFlag">产品的标签类型</typeparam>
    public interface IFactory<T, TFlag> where T : class
    {
        /// <summary>
        /// 获取物品
        /// </summary>
        /// <returns>返回物品</returns>
        T GetItem(TFlag flag);

        TK GetItem<TK>(TFlag flag) where TK : T;
    }
}
