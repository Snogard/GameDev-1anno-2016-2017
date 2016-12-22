#include "Entity.h"

Entity(string name, short health,short will,short attack,short intimidation):
            m_Name(name),
            m_Health(health),
            m_Will(will),
            m_Attack(attack),
            m_Intimidation(intimidation)
{}
bool Entity::isAlive()
{
    return health>0;
}
void Entity::printStatus()
{
    cout<<"Name: "<<m_Name<<endl;
    cout<<"Health: "<<m_Health<<endl;
    cout<<"Will: "<<m_Will<<endl;
}

