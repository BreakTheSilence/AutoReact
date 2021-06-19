using System.Collections.Generic;

namespace AutoReact.Interfaces.Schemas
{
    public interface ISchema
    {
        List<List<bool>> GetFirstPart();
        List<List<bool>> GetSecondPart();
        List<List<bool>> GetLittle();
        List<List<bool>> GetSkin();
    }
}