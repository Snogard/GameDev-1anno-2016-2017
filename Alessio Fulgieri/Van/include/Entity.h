#ifndef ENTITY_H
#define ENTITY_H
#include <string>

class Entity
{
    public:

        Entity(string name,short health,short will,short attack,short intimidation);
        bool isAlive();
        void printStatus();

    protected:

    private:
        string m_Name;
        short m_Health;
        short m_Will;
        short m_Attack;
        short m_Intimidation;

};

#endif // ENTITY_H
